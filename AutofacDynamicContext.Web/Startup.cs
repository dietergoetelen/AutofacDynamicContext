using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutofacDynamicContext.Web.Startup))]
namespace AutofacDynamicContext.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
