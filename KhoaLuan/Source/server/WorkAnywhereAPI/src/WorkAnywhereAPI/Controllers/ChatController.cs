namespace WorkAnywhereAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Web.Http;
    using Repository;
    using Microsoft.AspNetCore.Authorization;
    using MongoDB.Bson.IO;
    using System.Collections.Generic;
    using Models;
    using System.Linq;

    [Route("api/[controller]")]
    [AllowAnonymous]
    public class ChatController : Controller
    {
        private ChatRepository chatRepo = new ChatRepository();


        // Generate chanel
        [HttpGet]
        public string Get([FromUri] string userId, string postId, string receiveId, string name, string time, string imagePath)
        {
            var chanel = "";
            if (!chatRepo.IsExistChanel(userId, postId, out chanel))
            {
                chanel = $"{userId}@{postId}";
                chatRepo.Create(new Models.Chat()
                {
                    Chanel = chanel,
                    SensorId = userId,
                    ReceiveId = receiveId,
                    Name = name,
                    Time = time,
                    ImagePath = imagePath
                });
            }         
            return chanel;
        }

        [HttpGet("{id}")]
        public List<Chat> Post(string id)
        {
            if (id == null)
            {
                return null;
            }
            var chats = chatRepo.GetAll().Where(c => c.ReceiveId == id || c.SensorId == id);
            return chats.ToList();
        }
    }
}
