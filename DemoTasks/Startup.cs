using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoTasks.Startup))]
namespace DemoTasks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
