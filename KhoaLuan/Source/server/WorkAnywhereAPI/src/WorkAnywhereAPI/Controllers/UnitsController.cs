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
    public class UnitsController : Controller
    {
        private UnitsRepository unitRepo = new UnitsRepository();

        // GET: api/values
        [HttpGet]
        public IEnumerable<Unit> Get() => this.unitRepo.GetAll();
    }
}
