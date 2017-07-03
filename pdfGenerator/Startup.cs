using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pdfGenerator.Startup))]
namespace pdfGenerator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
