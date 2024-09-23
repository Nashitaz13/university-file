using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using WorkAnywhereAPI.Models;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WorkAnywhereAPI.Utilities
{
    public class NotificationManager
    {
        public async Task<string> CreateNotification(NotificationMessage notificationMessage)
        {
            var request = WebRequest.Create(@"https://onesignal.com/api/v1/notifications") as HttpWebRequest;
            request.Method = "POST";
            request.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
            request.Headers[HttpRequestHeader.Authorization] = "Basic ODkyMjdjZTctOWYzZC00MGMxLWE0Y2MtYzQzMDk0Njg5OTUx";

            var obj = new
            {
                app_id = "7095d3d7-3a10-4b6f-a35d-4c94ee5ae880",
                headings = notificationMessage.Title,
                contents = new { en = notificationMessage.Message }
            };

            var param = JsonConvert.SerializeObject(obj);
            byte[] byteArray = Encoding.UTF8.GetBytes(param);

            string responseContent = null;

            try
            {
                using (var writer = await request.GetRequestStreamAsync())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var response = await request.GetResponseAsync() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                    }
                }
                return responseContent;
            }
            catch (WebException ex)
            {
                return ex.Message;
            }

        }
    }
}
