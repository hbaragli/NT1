using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdministradordeRecursosHumanos.Startup))]
namespace AdministradordeRecursosHumanos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
