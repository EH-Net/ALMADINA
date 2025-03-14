using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ALMADINA.Startup))]
namespace ALMADINA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
