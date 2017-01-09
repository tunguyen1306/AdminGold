using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExampleStudy.Startup))]
namespace ExampleStudy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
