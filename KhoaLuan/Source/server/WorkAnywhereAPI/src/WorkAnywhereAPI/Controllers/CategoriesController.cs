using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorkAnywhereAPI.Repository;
using WorkAnywhereAPI.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkAnywhereAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class CategoriesController : Controller
    {
        private CategoriesRepository categoryRepo = new CategoriesRepository();

        // GET: api/values
        [HttpGet]
        public IEnumerable<Category> Get() => this.categoryRepo.GetAll();
    }
}
