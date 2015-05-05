using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SGTE_V1._8.Startup))]
namespace SGTE_V1._8
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
