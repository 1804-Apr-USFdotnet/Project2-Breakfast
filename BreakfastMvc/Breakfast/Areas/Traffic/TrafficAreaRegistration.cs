using System.Web.Mvc;

namespace Breakfast.Areas.Traffic
{
    public class TrafficAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Traffic";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Traffic_default",
                "Traffic/{controller}/{action}/{userId}",
                new { action = "Index", userId = UrlParameter.Optional }
            );
        }
    }
}