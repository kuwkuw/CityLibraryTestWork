using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CityLibraryTestWork.Startup))]
namespace CityLibraryTestWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
