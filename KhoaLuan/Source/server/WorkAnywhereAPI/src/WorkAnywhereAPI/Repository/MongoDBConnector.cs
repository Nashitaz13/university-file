using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WorkAnywhereAPI.Repository
{
    public class MongoDBConnector
    {
        #region Variables

        /// <summary>
        /// The mongodb client
        /// </summary>
        private MongoClient client;

        /// <summary>
        /// URI of connection
        /// </summary>
        // private readonly string URIConnection = "mongodb://phuongvh:phuong1994@ds048319.mlab.com:48319/mean-db";
        private readonly string URIConnection = "mongodb://localhost:27017/workanywhere";

        /// <summary>
        /// Database name
        /// </summary>
        private readonly string Database = "workanywhere";

        #endregion

        #region Publish methods

        /// <summary>
        /// Connect to mongodb by connection string and database name
        /// </summary>
        /// <param name="connectionString">The connection string</param>
        /// <param name="database">The database name</param>
        /// <returns>The MongoDatabase if connect mongodb successfully, else null.</returns>
        public async Task<IMongoDatabase> Connect()
        {
            try
            {
                this.client = new MongoClient(new MongoUrl(this.URIConnection));
                var database = this.client.GetDatabase(this.Database);
                var x = await database.RunCommandAsync<BsonDocument>(new BsonDocument("ping", 1));
                return database;
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent($"Cannot connect database. Exception: {ex.Message}.")
                };
                throw new HttpResponseException(resp);
            }
        }


        #endregion
    }
}
