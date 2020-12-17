using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Seminarski.Startup))]
namespace Seminarski
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
