using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCPractice.Startup))]
namespace MVCPractice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
