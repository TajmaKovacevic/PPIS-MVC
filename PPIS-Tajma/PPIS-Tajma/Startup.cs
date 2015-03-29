using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PPIS_Tajma.Startup))]
namespace PPIS_Tajma
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
