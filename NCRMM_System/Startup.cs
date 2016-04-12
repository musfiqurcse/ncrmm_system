using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NCRMM_System.Startup))]
namespace NCRMM_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
