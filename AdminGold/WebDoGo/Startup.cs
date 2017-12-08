using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebDoGo.Startup))]
namespace WebDoGo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
