using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZoipSwitch.Startup))]
namespace ZoipSwitch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
