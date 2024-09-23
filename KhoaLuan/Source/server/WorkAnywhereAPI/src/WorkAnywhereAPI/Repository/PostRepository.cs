using WorkAnywhereAPI.Models;
using WorkAnywhereAPI.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Driver;
using GeoCoordinatePortable;
using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace WorkAnywhereAPI.Repository
{
    public class PostRepository : AbstractRepository<Post>
    {
        #region Public methods
        /// <summary>
        /// Get post by post id
        /// </summary>
        /// <param name="Id">The post id</param>
        /// <returns></returns>
        public Post GetByPostId(string Id)
        {
            IList<Post> entityList = null;
            Task.Run(async () =>
            {
                entityList = await this.collection.Find(e => e.PostId.Equals(Id)).ToListAsync();
            }).Wait();
            if (entityList.Count == 0)
            {
                ExceptionHandling.NotFound($"User with Id = {Id} is not found.");
            }
            return entityList.FirstOrDefault();
        }

        /// <summary>
        /// Get all post and calculate distance from location user to location post
        /// </summary>
        /// <param name="location">The location of user</param>
        /// <returns>List posts</returns>
        public IList<Post> GetAll(string type, GeoPoint userLocation)
        {
            try
            {
                List<Post> entityList = null;
                Task.Run(async () =>
                {
                    entityList = await this.collection.Find(p => p.Type.Equals(type)).ToListAsync();
                }).Wait();
                return this.FilfullData(entityList, userLocation);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get all post and calculate distance from location user to location post
        /// </summary>
        /// <param name="location">The location of user</param>
        /// <returns>List posts</returns>
        public IList<Post> GetAll(string type, int limit, GeoPoint userLocation)
        {
            try
            {
                IList<Post> entityList = null;
                Task.Run(async () =>
                {
                    entityList = await this.collection.Find(p => p.Type.Equals(type)).ToListAsync();
                }).Wait();
                // Sort by id
                var result = entityList.OrderBy(i => i.CreatedDate);
                return this.FilfullData(result.ToList(), userLocation).Take(limit).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get post by id
        /// </summary>
        /// <param name="Id">Id of post</param>
        /// <param name="location">Location of user</param>
        /// <returns></returns>
        public Post GetById(long Id, GeoCoordinate location, GeoPoint userLocation)
        {
            List<Post> entityList = null;
            Task.Run(async () =>
            {
                entityList = await this.collection.Find(e => e.PostId.Equals(Id)).ToListAsync();
            }).Wait();
            if (entityList.Count == 0)
            {
                ExceptionHandling.NotFound($"User with Id = {Id} is not found.");
            }
            this.FilfullData(entityList, userLocation);
            return entityList.FirstOrDefault();
        }

        /// <summary>
        /// Get posts by author (authorId)
        /// </summary>
        /// <param name="authorId">The user id</param>
        /// <returns>List posts</returns>
        public IList<Post> GetPostBy(string authorId, GeoPoint userLocation)
        {                 
            List<Post> entityList = null;
            Task.Run(async () =>
            {
                entityList = await this.collection.Find(e => e.AuthorId.Equals(authorId)).ToListAsync();
            }).Wait();
            return this.FilfullData(entityList, userLocation); 
        }

        /// <summary>
        /// Get posts by author (authorId)
        /// </summary>
        /// <param name="authorId">The user id</param>
        /// <returns>List posts</returns>
        public List<Post> SearchPost(string searchString, GeoPoint userLocation)
        {
            List<Post> entityList = null;
            Task.Run(async () =>
            {
                entityList = await this.collection.Find(e => e.Title.Contains(searchString)).ToListAsync();
            }).Wait();
            return this.FilfullData(entityList, userLocation);
        }

        /// <summary>
        /// Get post filter by list categories and salary
        /// </summary>
        /// <param name="categories">List category</param>
        /// <param name="salary">The salary</param>
        /// <returns>List posts</returns>
        public List<Post> GetPostFilterBy(List<int> categories, long salary, GeoPoint userLocation)
        {
            List<Post> entityList = new List<Post>();
            var builder = Builders<Post>.Filter;
            foreach(var category in categories)
            {
                var filter = builder.Eq("category", category) & builder.Gte("salary", salary);
                Task.Run(async () =>
                {
                    entityList.AddRange(await this.collection.Find(filter).ToListAsync());
                }).Wait();
            }
            return this.FilfullData(entityList, userLocation);
        }

        private List<Post> FilfullData(List<Post> posts, GeoPoint userLocation)
        {
            List<Post> result = new List<Post>();
            var userRepo = new UserRepository();
            foreach (var post in posts)
            {
                var user = userRepo.GetById(post.AuthorId);
                post.AuthorName = user.DisplayName;
                var str = "";
                post.DistanceNumber = Utilities.ConvertDistanceHelper.ConvertMeterToKilometers(this.CalculateDistance(userLocation, post.Location, out str));
                post.Distance = str;
                result.Add(post);
            }
            return result;
        }

        private double CalculateDistance(GeoPoint start, GeoPoint destination, out string distanceString)
        {
            var apiKey = "AIzaSyA3d7Gwh21-3xq64N8yldSdTzR1WVz7zLU";
            var requestUri =$"https://maps.googleapis.com/maps/api/distancematrix/json?units=metric&origins={start.Latitude},{start.Longitude}&destinations={destination.Latitude},{destination.Longitude}&key={apiKey}";
            var request = WebRequest.Create(requestUri);
            WebResponse response = null;
            Task.Run(async () =>
            {
                response = await request.GetResponseAsync();
            }).Wait();
            using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
            {
                string responseText = reader.ReadToEnd();
                JObject jsonObj = JObject.Parse(responseText);
                JToken value = jsonObj.SelectToken("rows[0].elements[0].distance.value");
                JToken valueString = jsonObj.SelectToken("rows[0].elements[0].distance.text");
                if (value != null && valueString !=  null)
                {
                    distanceString = (string)valueString;
                    return (double)value;
                }
                else
                {
                    distanceString = "";
                    return -1;
                }
            }
        }      

        #endregion
    }
}
