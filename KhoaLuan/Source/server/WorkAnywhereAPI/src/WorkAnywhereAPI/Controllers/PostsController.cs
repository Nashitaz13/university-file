using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorkAnywhereAPI.Repository;
using WorkAnywhereAPI.Models;
using System.Web.Http;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;

namespace WorkAnywhereAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class PostsController : Controller
    {
        #region Variables

        /// <summary>
        /// The post repository
        /// </summary>
        private PostRepository postRepository = new PostRepository();

        #endregion

        #region Public API

        // GET: api/values
        [HttpGet]
        public IEnumerable<Post> Get([FromUri]string type, GeoPoint userLocation, int limit, string salary, string radius, string contractypes, string categories)
        {
            var resultPosts = this.postRepository.GetAll(type, (int)limit, userLocation);
            // Build list contractype
            var contractypesList = contractypes.Split('-').ToList();
            var categoriesList = categories.Split('-').ToList();

            return this.FilterPost(resultPosts.ToList(), double.Parse(salary), double.Parse(radius), contractypesList, categoriesList);
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public Post Get(string id) => this.postRepository.GetByPostId(id);

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Post post)
        {
            if (post == null)
            {
                return BadRequest();
            }
            // Set GUID for post
            post.PostId = Guid.NewGuid().ToString();
            this.postRepository.Create(post);
            return new OkObjectResult(true);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]Post post)
        {
            if (!id.Equals(post.PostId) || post == null)
            {
                return BadRequest();
            }
            this.postRepository.Update(post);
            return new OkObjectResult(true);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var post = this.postRepository.GetByPostId(id);
            if (post == null)
            {
                return BadRequest();
            }
            this.postRepository.Delete(post);
            return new OkObjectResult(true);
        }

        #endregion

        #region Internal methods

        public List<Post> FilterPost(List<Post> listPosts, double salary, double radius, List<string> contractypes, List<string> categories)
        {
            // Lọc theo lương & ban kinh
            var resultPost = listPosts.Where(p => p.Salary >= salary && p.DistanceNumber <= radius);
            // Lọc theo hình thức làm việc
            resultPost = resultPost.Where(p => contractypes.Contains(p.ContractType.ToString()));
            // Lọc theo category
            resultPost = resultPost.Where(p => categories.Contains(p.Category.ToString()));
            return resultPost.ToList();
        }


        
        #endregion
    }
}
