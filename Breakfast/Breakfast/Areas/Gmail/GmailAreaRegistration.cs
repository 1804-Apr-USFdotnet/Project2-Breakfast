using System.Web.Mvc;

namespace Breakfast.Areas.Gmail
{
    public class GmailAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Gmail";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Gmail_default",
                "Gmail/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}