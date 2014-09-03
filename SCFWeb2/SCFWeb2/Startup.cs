using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SCFWeb2.Startup))]
namespace SCFWeb2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
