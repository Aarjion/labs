using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Бипит_лаба_10.Startup))]
namespace Бипит_лаба_10
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
