using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZimtProcure2Pay.Startup))]
namespace ZimtProcure2Pay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
