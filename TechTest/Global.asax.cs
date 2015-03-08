using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using TechTest.App_Start;

namespace TechTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MapperConfig.SetupMappings();
        }
    }
}
