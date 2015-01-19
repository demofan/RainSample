using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rain.Startup))]
namespace Rain
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
