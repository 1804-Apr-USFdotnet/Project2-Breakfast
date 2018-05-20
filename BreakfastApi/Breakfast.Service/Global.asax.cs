using Breakfast.Service.App_Start;
using System.Web.Http;
using System.Web.Routing;

namespace Breakfast.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteTable.Routes.RouteExistingFiles = true;

            GlobalConfiguration.Configure(WebApiConfig.Register);

            //WebApiConfig.Register(GlobalConfiguration.Configuration); //register api routes
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
