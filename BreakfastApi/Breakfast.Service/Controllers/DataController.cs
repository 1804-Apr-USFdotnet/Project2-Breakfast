using Breakfast.Business.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Breakfast.Business.Traffic;


namespace Breakfast.Service.Controllers
{
    public class DataController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(string))]
        [Route("api/weather/get/{zipcode}")]
        public IHttpActionResult WeatherData(string zipcode)
        {
            try { return Ok(OpenWeatherMapApi.GetResponse(zipcode)); }
            catch { return InternalServerError(); }
        }

        [HttpGet]
        [ResponseType(typeof(string))]
        [Route("api/traffic/get/{homePlaceId}/{workPlaceId}/{travelMode}")]
        public IHttpActionResult TrafficTimeToWork(string homePlaceId, string workPlaceId, string travelMode)
        {
            try
            {
                return Ok(TrafficApi.GetTimeToWork(homePlaceId, workPlaceId, travelMode));
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}
