using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(paup_mcp.Startup))]
namespace paup_mcp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
