using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PORTAFOLIO_SAMUEL.Startup))]
namespace PORTAFOLIO_SAMUEL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
