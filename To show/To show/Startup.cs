using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(To_show.Startup))]
namespace To_show
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
