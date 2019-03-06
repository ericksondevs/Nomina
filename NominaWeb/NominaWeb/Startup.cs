using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NominaWeb.Startup))]
namespace NominaWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
