using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IndianRestaurant.Startup))]
namespace IndianRestaurant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
