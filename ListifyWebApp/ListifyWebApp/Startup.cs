using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ListifyWebApp.Startup))]
namespace ListifyWebApp
{
    public partial class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
