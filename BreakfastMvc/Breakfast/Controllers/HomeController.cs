using Breakfast.Areas.News.Models;
using Breakfast.Areas.Weather.Models;
using Breakfast.Models;
using Breakfast.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Breakfast.Areas.Traffic.Models;

namespace Breakfast.Controllers
{
    public class HomeController : AsyncController
    {
        private static string _settingsApiKey;

        public async Task<ActionResult> Index()
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
                    weatherData = new OpenWeatherMap(currentUser.zipcode),
                    // get traffic data for current user
                    trafficData = (TrafficSettingsViewModel) new SettingsModel().GetSettings(User.Identity.Name).Traffic,
                    // get news data for current user
                    // TODO
                    articles = NewsArticle.GetArticles(currentUser.UserName)
                };
                //traffic data for viewbags
                string timeToWork =  await TrafficSettingsViewModel.SetTimeToWork(data.trafficData);
                string travelMode = (data.trafficData.Driving) ? "DRIVING" : "WALKING";
                string apiKey = data.trafficData.getApiKey();
                _settingsApiKey = apiKey;
                ViewBag.TimeToWork = timeToWork;
                ViewBag.TravelMode = travelMode;
                ViewBag.APIKey = apiKey;

                if (data.settings.Weather.farenheit == false)
                    data.weatherData.ToCelcius();

                return View(data);
            }
            else
                return View(new Data());
        }

        public ActionResult About()
        {
            return View("About");
        }

        public ActionResult Contact()
        {
            return View("Contact");
        }

        public ActionResult Settings()
        {
            var rootSettings = new SettingsModel().GetSettings(User.Identity.Name);
            var trafficViewModel = (TrafficSettingsViewModel) rootSettings.Traffic;
            ViewBag.APIKey = trafficViewModel.getApiKey();
            
            return View(new SettingsModel().GetSettings(User.Identity.Name));
        }

        [HttpPost]
        public ActionResult SaveWeatherSettings(Weather weather)
        {
            new SettingsModel().SaveWeatherSettings(User.Identity.Name, weather);
            return RedirectToAction("index", "home");
        }

        [HttpPost]
        public ActionResult SaveTrafficSettings(Traffic traffic)
        {
            new SettingsModel().SaveTrafficSettings(User.Identity.Name, traffic);
            return RedirectToAction("index", "home");
        }

        [HttpPost]
        public ActionResult SaveNewsSettings(News news)
        {
            new SettingsModel().SaveNewsSettings(User.Identity.Name, news);
            return RedirectToAction("index", "home");
        }

    }
}