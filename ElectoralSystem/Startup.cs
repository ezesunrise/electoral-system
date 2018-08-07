using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElectoralSystem.Startup))]
namespace ElectoralSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
