using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WorkAnywhereAPI.Utilities
{
    public static class ExceptionHandling
    {
        /// <summary>
        /// Throw exception in case object not found
        /// </summary>
        /// <param name="message">Error message</param>
        public static HttpResponseMessage NotFound(string message)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(message)
            };
            return resp;
        }

        /// <summary>
        /// Throw exception when has bad request
        /// </summary>
        /// <param name="message">Error message</param>
        public static HttpResponseMessage BadRequest(string message)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(message)
            };
            return resp;
        }
    }
}
