using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelpDesk2.Startup))]
namespace HelpDesk2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
