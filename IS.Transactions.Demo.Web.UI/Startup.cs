using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IS.Transactions.Demo.Web.UI.Startup))]
namespace IS.Transactions.Demo.Web.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
