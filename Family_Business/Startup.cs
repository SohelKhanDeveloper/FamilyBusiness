using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Family_Business.Startup))]
namespace Family_Business
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
