using Breakfast.Business;
using Breakfast.Business.Weather;
using Breakfast.Business.Weather.Models;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Breakfast.Business.Traffic.Models;
using Breakfast.Business.Traffic;

namespace Breakfast.Service.Controllers
{
    public class SettingsController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(void))]
        public IHttpActionResult TestResponse()
        {
            return Ok();
        }

        [HttpGet]
        [ResponseType(typeof(SettingsModel))]
        public IHttpActionResult GetSettings(string userId)
        {
            SettingsModel settings = Settings.getSettings(userId);
            try { return Ok(settings); }
            catch { return InternalServerError(); }
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult InitializeSettings(string userId)
        {
            try { Settings.initializeSettings(userId); return StatusCode(HttpStatusCode.Created); }
            catch { return InternalServerError(); }
        }

        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult SaveWeatherSettings(string userId, WeatherSettings ws)
        {
            try { WeatherCrud.SaveSettings(userId, ws); return StatusCode(HttpStatusCode.Accepted); }
            catch { return InternalServerError(); }
        }

        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult SaveTrafficSettings(string userId, TrafficSettingsBusiness ts)
        {
            try { TrafficCrud.SaveSettings(userId, ts); return StatusCode(HttpStatusCode.Accepted); }
            catch { return InternalServerError(); }
        }
    }
}
