using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NITBook.Startup))]
namespace NITBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
