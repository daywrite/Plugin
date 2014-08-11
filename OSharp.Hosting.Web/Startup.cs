using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcWebFramework.Startup))]
namespace MvcWebFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
