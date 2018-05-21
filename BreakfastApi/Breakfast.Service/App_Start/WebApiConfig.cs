using System.Web.Http;
using System.Web.Http.Cors;

namespace Breakfast.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute(
               origins: "*",  //TODO: replace with ec2 endpoints that are hosting deployed mvc/angular projects
               headers: "*",
               methods: "get,post,put"
           );
            config.EnableCors(cors);


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "Default",
            //    routeTemplate: "",
            //    defaults: new { controller = "Settings" }
            //);
        }
    }
}
