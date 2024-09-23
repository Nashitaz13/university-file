using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorkAnywhereAPI.Models;
using WorkAnywhereAPI.Repository;
using WorkAnywhereAPI.Utilities;
using Microsoft.AspNetCore.Authorization;
using System;

namespace WorkAnywhereAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        #region Variables

        /// <summary>
        /// The user repository
        /// </summary>
        private UserRepository userRepository = new UserRepository();

        #endregion

        #region Public API

        // GET: api/users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return this.userRepository.GetAll();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public User Get(string id) => this.userRepository.GetById(id);

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            // Set GUID for post
            user.UserId = Guid.NewGuid().ToString();
            // Encrypt password
            var hashPassword = HashPasswod.EncryptPassword(user.Password);
            user.Password = hashPassword;
            this.userRepository.Create(user);
            return new OkObjectResult(true);
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody]User user)
        {
            if (!id.Equals(user.UserId) || user == null)
            {
                ExceptionHandling.BadRequest("The request is invalid.");
            }
            this.userRepository.Update(user);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var user = this.userRepository.GetById(id);
            if (user == null)
            {
                ExceptionHandling.BadRequest("The request is invalid.");
            }
            this.userRepository.Delete(user);
        }

        #endregion
    }
}
