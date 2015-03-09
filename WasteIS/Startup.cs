using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WasteIS.Startup))]
namespace WasteIS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
