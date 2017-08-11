using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IIUCImagineProject.Startup))]
namespace IIUCImagineProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
