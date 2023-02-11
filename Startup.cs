using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Portfolio.Startup))]
namespace Portfolio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
