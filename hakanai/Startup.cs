using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hakanai.Startup))]
namespace hakanai
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
