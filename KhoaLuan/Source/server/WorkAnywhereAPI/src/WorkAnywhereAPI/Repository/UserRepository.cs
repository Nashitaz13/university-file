using WorkAnywhereAPI.Models;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using WorkAnywhereAPI.Utilities;
using System;

namespace WorkAnywhereAPI.Repository
{
    public class UserRepository : AbstractRepository<User>
    {
        /// <summary>
        /// Get user by user id
        /// </summary>
        /// <param name="Id">The user id</param>
        /// <returns></returns>
        public User GetById(string Id)
        {
            IList<User> entityList = null;
            Task.Run(async () =>
            {
                entityList = await this.collection.Find(e => e.UserId == Id).ToListAsync();
            }).Wait();
            if(entityList.Count == 0)
            {
                ExceptionHandling.NotFound($"User with Id = {Id} is not found.");
            }    
            return entityList.FirstOrDefault();
        }

        /// <summary>
        /// Check user login
        /// </summary>
        /// <param name="user">The instance user</param>
        /// <returns>True if login successfully, else false.</returns>
        public bool ValidatedLogin(User user, out string userid)
        {
            IList<User> entityList = null;
            var hashPassword = HashPasswod.EncryptPassword(user.Password);
            Task.Run(async () =>
            {
                entityList = await this.collection.Find(e => 
                    e.UserName.Equals(user.UserName) && e.Password.Equals(hashPassword)).ToListAsync();
            }).Wait();
            if (entityList.Count > 0)
            {
                userid = entityList.FirstOrDefault().UserId;
                return true;
            }
            else
            {
                userid = string.Empty;
                return false;
            }
        }
        
        public bool IsExistUserName(string userName, out string userid)
        {
            IList<User> entityList = null;
            Task.Run(async () =>
            {
                entityList = await this.collection.Find(e => e.UserName.Equals(userName)).ToListAsync();
            }).Wait();
            if (entityList.Count > 0)
            {
                userid = entityList.FirstOrDefault().UserId;
                return true;
            }
            else
            {
                userid = string.Empty;
                return false;
            }
        }
    }
}
