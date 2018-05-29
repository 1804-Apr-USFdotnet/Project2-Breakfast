using Breakfast.Business;
using Breakfast.Business.Weather;
using Breakfast.Business.Weather.Models;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Breakfast.Business.Traffic.Models;
using Breakfast.Business.Traffic;
using System;
using System.Diagnostics;
using Breakfast.Business.News;
using Breakfast.Business.News.Models;
using NLog;

namespace Breakfast.Service.Controllers
{
    public class SettingsController : ApiController
    {
        static private Logger logger = LogManager.GetCurrentClassLogger();

        [HttpGet]
        [ResponseType(typeof(void))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("test/testresponse")]
        public IHttpActionResult TestResponse()
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return InternalServerError();
            }
        }

        [HttpGet]
        [ResponseType(typeof(SettingsModel))]
        [Route("api/settings/get/{userId}")]
        public IHttpActionResult GetSettings(string userId)
        {
            SettingsModel settings = Settings.getSettings(userId);
            try
            {
                return Ok(settings);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return InternalServerError();
            }
        }

        [HttpGet]
        [ResponseType(typeof(void))]
        [Route("api/settings/initialize/{userId}")]
        public IHttpActionResult InitializeSettings(string userId)
        {
            try
            {
                Settings.initializeSettings(userId);
                return StatusCode(HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return InternalServerError();
            }
        }

        [HttpGet]
        [ResponseType(typeof(void))]
        [Route("api/settings/initialize/{userId}/{homeAddress}/{workAddress}")]
        public IHttpActionResult InitializeSettings(string userId, string homeAddress, string workAddress)
        {
            try
            {
                Settings.initializeSettings(userId, homeAddress, workAddress);
                return StatusCode(HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return InternalServerError();
            }
        }

        [HttpPost]
        [ResponseType(typeof(void))]
        [Route("api/settings/weather/{userId}")]
        public IHttpActionResult SaveWeatherSettings(string userId, WeatherSettings ws)
        {
            try
            {
                WeatherCrud.SaveSettings(userId, ws);
                return StatusCode(HttpStatusCode.Accepted);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return InternalServerError();
            }
        }

        [HttpPost]
        [ResponseType(typeof(void))]
        [Route("api/settings/traffic/{userId}")]
        public IHttpActionResult SaveTrafficSettings(string userId, TrafficSettingsBusiness ts)
        {
            try
            {
                TrafficCrud.SaveSettings(userId, ts);
                return StatusCode(HttpStatusCode.Accepted);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return InternalServerError();
            }
        }

        [HttpPost]
        [ResponseType(typeof(void))]
        [Route("api/settings/news/{userId}")]
        public IHttpActionResult SaveNewsSettigs (string userId, NewsSettings ns)
        {
            try
            {
                NewsCrud.SaveSettings(userId, ns);
                return StatusCode(HttpStatusCode.Accepted);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return InternalServerError();
            }
        }
    }
}
