using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using WorkAnywhereAPI.Models;
using WorkAnywhereAPI.Repository;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkAnywhereAPI.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private PostRepository postRepo = new PostRepository();

        // GET: api/values
        [HttpGet]
        public List<Post> Get([FromUri]string seachString, GeoPoint userLocation) => this.postRepo.SearchPost(seachString, userLocation);
    }
}
