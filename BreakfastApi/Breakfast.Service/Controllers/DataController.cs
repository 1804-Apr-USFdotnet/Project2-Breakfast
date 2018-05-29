using Breakfast.Business.News;
using Breakfast.Business.News.Models;
using Breakfast.Business.Weather;
using Breakfast.Business.Weather.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Breakfast.Business.Traffic;
using NLog;

namespace Breakfast.Service.Controllers
{
    public class DataController : ApiController
    {
        static private Logger logger = LogManager.GetCurrentClassLogger();

        [HttpGet]
        [ResponseType(typeof(CurrentWeather))]
        [Route("api/weather/get/{zipcode}")]
        public IHttpActionResult WeatherData(string zipcode)
        {
            try
            {
                return Ok(OpenWeatherMapApi.GetResponse(zipcode));
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return InternalServerError();
            }
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<NewsArticle>))]
        [Route("api/news/getArticles/{userId}")]
        public IHttpActionResult GetArticles(string userId)
        {
            try
            {
                NewsSettings settings = NewsCrud.ReadSettings(userId);
                NewsApiClient client = new NewsApiClient(settings);
                IEnumerable<NewsArticle> articles = client.GetNewsArticles(1);
                return Ok(articles);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return InternalServerError();
            }
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<NewsArticle>))]
        [Route("api/news/activeGetArticles/{queryString}")]
        public IHttpActionResult ActiveGetArticles(string queryString)
        {
            try
            {
                NewsSettings settings = new NewsSettings ();
                NewsApiClient client = new NewsApiClient(settings);
                IEnumerable<NewsArticle> articles = client.GetNewsArticles(queryString);
                return Ok(articles);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return InternalServerError();
            }
        }

        [HttpGet]
        [ResponseType(typeof(string))]
        [Route("api/traffic/get/{homePlaceId}/{workPlaceId}/{travelMode}/{version}")]
        public async System.Threading.Tasks.Task<IHttpActionResult> TrafficTimeToWorkAsync(string homePlaceId, string workPlaceId, string travelMode, string version)
        {
            try
            {
                if (version == "1")
                    return Ok(await TrafficApi.GetTimeToWork(homePlaceId, workPlaceId, travelMode));
                
                //not place id's but regular strings
                return Ok(await TrafficApi.GetTimeToWorkString(homePlaceId, workPlaceId, travelMode));
                
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return InternalServerError();
            }
        }
    }
}
