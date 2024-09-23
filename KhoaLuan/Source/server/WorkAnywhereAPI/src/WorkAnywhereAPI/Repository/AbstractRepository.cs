using MongoDB.Driver;
using WorkAnywhereAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Linq;

namespace WorkAnywhereAPI.Repository
{
    /// <summary>
    /// Abstract class implement interface IRepository
    /// </summary>
    /// <typeparam name="T">Entity base</typeparam>
    public abstract class AbstractRepository<T> : IRepository<T> where T : EntityBase
    {
        #region Variables

        private MongoDBConnector mongoConnector = new MongoDBConnector();
        protected IMongoCollection<T> collection;

        #endregion

        #region Constructor

        public AbstractRepository()
        {
            this.SetMongoCollection().Wait();
        }

        #endregion

        #region Internal methods 

        private async Task SetMongoCollection()
        {
            Type type = typeof(T);// Get name of class
            var database = await this.mongoConnector.Connect();
            this.collection = database.GetCollection<T>($"{type.Name}");
        }

        #endregion

        #region Public method

        /// <summary>
        /// Get all entity
        /// </summary>
        /// <returns>List entity</returns>
        public IList<T> GetAll()
        {
            IList<T> entityList = null;
            Task.Run(async () =>
            {
                entityList = await this.collection.Find(Builders<T>.Filter.Empty).ToListAsync();
            }).Wait();
            return entityList;
        }

        /// <summary>
        /// Get entity by Object Id
        /// </summary>
        /// <param name="Id">Id of entity</param>
        /// <returns>Entity if it found, else exception</returns>
        public T GetByObjectId(string Id)
        {
            IList<T> entityList = null;
            Task.Run(async () =>
            {
                entityList = await this.collection.Find(e => e.Id.Equals(Id)).ToListAsync();
            }).Wait();            
            return entityList.FirstOrDefault();
        }

        /// <summary>
        /// Create new entity
        /// </summary>
        /// <param name="entity">The entity</param>
        public void Create(T entity)
        {
            Task.Run(async () => 
            {
                await this.collection.InsertOneAsync(entity);
            }).Wait();
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>List entity after delete successfully</returns>
        public void Delete(T entity)
        {
            Task.Run(async () => 
            {
                await this.collection.DeleteOneAsync(c => c.Id == entity.Id);
            }).Wait();
        }

        /// <summary>
        /// Update entity exists
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>List entity after update successfully</returns>
        public void Update(T entity)
        {
            var filter = Builders<T>.Filter.Eq(e => e.Id, entity.Id);
            Task.Run(async () =>
            {
                await this.collection.ReplaceOneAsync(filter, entity, new UpdateOptions { IsUpsert = true });
            }).Wait();
        }

        /// <summary>
        /// Update a property of entity object
        /// </summary>
        /// <param name="entity"></param>
        public T UpdateProperty(T entity, string property, string value)
        {
            var filter = Builders<T>.Filter.Eq(e => e.Id, entity.Id);
            var update = Builders<T>.Update.Set(property, value);
            Task.Run(async () =>
            {
                await this.collection.UpdateOneAsync(filter, update);
            }).Wait();
            return this.GetByObjectId(entity.Id);
        }

        #endregion
    }
}
