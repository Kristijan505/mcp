using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServisVozila.Startup))]
namespace ServisVozila
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
