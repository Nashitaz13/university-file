using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WorkAnywhereAPI.Repository;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkAnywhereAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class IsExistUserController : Controller
    {

        private UserRepository userRepo = new UserRepository();
        private string userId; 

        // GET: api/values/username
        [HttpGet("{username}")]
        public bool Get(string username) => this.userRepo.IsExistUserName(username, out this.userId);
    }
}
