using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KYF_Code_First_.Startup))]
namespace KYF_Code_First_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
