using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hLib.Startup))]
namespace hLib
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
