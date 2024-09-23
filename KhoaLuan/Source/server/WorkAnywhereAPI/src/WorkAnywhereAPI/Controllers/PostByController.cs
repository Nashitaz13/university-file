using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WorkAnywhereAPI.Models;
using WorkAnywhereAPI.Repository;
using System.Web.Http;

namespace WorkAnywhereAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class PostByController : Controller
    {
        private PostRepository postRepo = new PostRepository();

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<Post> Get(string id, [FromUri] GeoPoint userLocation)
        {
            if(userLocation == null)
            {
                userLocation = new GeoPoint();
            }
            return this.postRepo.GetPostBy(id, userLocation);
        }
    }
}
