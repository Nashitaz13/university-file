using WorkAnywhereAPI.Models;
using System.Collections.Generic;

namespace WorkAnywhereAPI.Repository
{
    public interface IRepository<T> where  T : EntityBase
    {

        /// <summary>
        /// Get all entity
        /// </summary>
        /// <returns>List entity</returns>
        IList<T> GetAll();

        /// <summary>
        /// Create new entity
        /// </summary>
        /// <param name="entity">The entity</param>
        void Create(T entity);

        /// <summary>
        /// Update entity exists
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>List entity after update successfully</returns>
        void Update(T entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>List entity after delete successfully</returns>
        void Delete(T entity);
    }
}
