using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RoutingURL.Startup))]
namespace RoutingURL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
