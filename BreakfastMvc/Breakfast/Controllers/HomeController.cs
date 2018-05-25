using Breakfast.Areas.Weather.Models;
using Breakfast.Models;
using Breakfast.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Breakfast.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                string currentUserId = User.Identity.GetUserId();
                AppDbContext db = new AppDbContext();
                AppUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
                Data data = new Data()
                {
                    // get settings for current user
                    settings = new SettingsModel().GetSettings(User.Identity.Name),
                    // get weather data for current user
                    weatherData = new OpenWeatherMap(currentUser.zipcode)
                    // get traffic data for current user
                    // TODO
                    // get news data for current user
                    // TODO
                };

                if (data.settings.Weather.farenheit == false)
                    data.weatherData.ToCelcius();

                return View(data);
            }
            else
                return View(new Data());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Settings()
        {
            return View(new SettingsModel().GetSettings(User.Identity.Name));
        }

        [HttpPost]
        public ActionResult SaveWeatherSettings(Weather weather)
        {
            new SettingsModel().SaveWeatherSettings(User.Identity.Name, weather);
            return RedirectToAction("index", "home");
        }
    }
}