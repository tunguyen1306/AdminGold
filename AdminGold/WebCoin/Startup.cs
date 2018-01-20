using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebCoin.Startup))]
namespace WebCoin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
