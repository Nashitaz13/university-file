namespace WorkAnywhereAPI.Repository
{
    using Models;
    using MongoDB.Driver;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ChatRepository : AbstractRepository<Chat>
    {
        public bool IsExistChanel(string userId, string postId, out string chanel)
        {
            List<Chat> entityList = null;
            var chanelName = $"{userId}@{postId}";
            Task.Run(async () =>
            {
                entityList = await this.collection.Find(e => e.Chanel.Equals(chanelName)).ToListAsync();
            }).Wait();
          
            if(entityList != null && entityList.Count > 0)
            {
                chanel = entityList.FirstOrDefault().Chanel;
                return true;
            }
            else
            {
                chanel = "";
                return false;
            }
        }

    }
}
