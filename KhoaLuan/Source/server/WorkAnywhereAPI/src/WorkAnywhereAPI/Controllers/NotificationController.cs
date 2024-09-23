using Microsoft.AspNetCore.Mvc;
using WorkAnywhereAPI.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using WorkAnywhereAPI.Utilities;
using WorkAnywhereAPI.Repository;
using System;
using System.Collections.Generic;
using System.Web.Http;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkAnywhereAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class NotificationController : Controller
    {
        private NotificationRepository notificationRepository = new NotificationRepository();


        // GET: api/values
        [HttpGet]
        public List<Notification> Get([FromUri]string type)
        {
            if(type != null)
            {
                return this.notificationRepository.GetNotificationByType(type);
            }
            return null;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Notification notification)
        {
            if (notification != null)
            {
                notification.Created = DateTime.Now.ToLocalTime();
                // Save notification to database
                this.notificationRepository.Create(notification);
                return new OkObjectResult(true);
            }
            return BadRequest();
        }
        
    }
}
