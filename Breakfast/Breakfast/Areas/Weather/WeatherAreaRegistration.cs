using System.Web.Mvc;

namespace Breakfast.Areas.Weather
{
    public class WeatherAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Weather";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Weather_default",
                "Weather/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}