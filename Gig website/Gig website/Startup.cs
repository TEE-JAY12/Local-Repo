using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gig_website.Startup))]
namespace Gig_website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
