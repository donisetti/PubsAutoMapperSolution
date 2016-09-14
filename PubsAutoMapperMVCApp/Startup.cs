using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PubsAutoMapperMVCApp.Startup))]
namespace PubsAutoMapperMVCApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
