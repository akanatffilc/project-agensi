using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Agensi.Web.Startup))]
namespace Agensi.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
