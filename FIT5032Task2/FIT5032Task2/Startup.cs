using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FIT5032Task2.Startup))]
namespace FIT5032Task2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
