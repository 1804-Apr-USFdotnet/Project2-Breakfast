using Breakfast.Areas.Weather.Models;
//using Breakfast.Data;
using System.Web.Mvc;

namespace Breakfast.Areas.Weather.Controllers
{
    public class OpenWeatherMapController : Controller
    {
        // GET: Weather/OpenWeatherMap
        public ActionResult Index()
        {
            return View(new OpenWeatherMap());
        }

        [HttpPost]
        public ActionResult Index(string zipcode)
        {
            OpenWeatherMap owm = new OpenWeatherMap(zipcode);
            return View(owm);
        }

        public ActionResult Settings()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveSettings(WeatherSettings ws)
        {
            //Storage storage = new Storage(new DefaultDBUtils());
            //storage.SaveWeatherSettings((Data.Models.WeatherSettings)ws);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}