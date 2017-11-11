using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bwright_budget.Startup))]
namespace bwright_budget
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
