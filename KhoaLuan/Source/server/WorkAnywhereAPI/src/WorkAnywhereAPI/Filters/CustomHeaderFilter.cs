using Microsoft.AspNetCore.Mvc.Filters;

namespace WorkAnywhereAPI.Filters
{
    public class CustomHeaderFilter : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.HttpContext.Response.Headers.Contains(new System.Collections.Generic.KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Access-Control-Allow-Origin", "http://localhost:8100")))
            {
                context.HttpContext.Response.Headers.Remove("Access-Control-Allow-Origin");
            }
            base.OnResultExecuting(context);
        }
    }
}
