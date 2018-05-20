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
        }
    }
}
