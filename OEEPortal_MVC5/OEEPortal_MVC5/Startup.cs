using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OEEPortal_MVC5.Startup))]
namespace OEEPortal_MVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
