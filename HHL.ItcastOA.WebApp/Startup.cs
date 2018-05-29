using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HHL.ItcastOA.WebApp.Startup))]
namespace HHL.ItcastOA.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
