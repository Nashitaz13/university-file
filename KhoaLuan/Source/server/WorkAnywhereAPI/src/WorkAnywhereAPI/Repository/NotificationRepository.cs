using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkAnywhereAPI.Models;

namespace WorkAnywhereAPI.Repository
{
    public class NotificationRepository : AbstractRepository<Notification>
    {
        private const string ChatType = "chat";

        public List<Notification> GetNotificationByType(string type)
        {
            List<Notification> entityList = null;
            Task.Run(async () =>
            {
                entityList = await this.collection.Find(n => n.Type == null ? false : n.Type.Equals(ChatType)).ToListAsync();
            }).Wait();
            return entityList;
        }
    }
}
