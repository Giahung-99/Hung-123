using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Giahung_Lab456.Startup))]
namespace Giahung_Lab456
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
