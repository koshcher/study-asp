using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityFrame.Startup))]
namespace IdentityFrame
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
