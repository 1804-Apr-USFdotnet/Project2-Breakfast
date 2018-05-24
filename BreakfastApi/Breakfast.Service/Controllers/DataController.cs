using Breakfast.Business.News;
using Breakfast.Business.News.Models;
using Breakfast.Business.Weather;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;


namespace Breakfast.Service.Controllers
{
    public class DataController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(CurrentWeather))]
        [Route("api/weather/get/{zipcode}")]
        public IHttpActionResult WeatherData(string zipcode)
        {
            try { return Ok(OpenWeatherMapApi.GetResponse(zipcode)); }
            catch (Exception e) { Debug.WriteLine(e); return InternalServerError(); }
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<NewsArticle>))]
        [Route("api/news/getArticles/{userId}")]
        public IHttpActionResult GetArticles(string userId)
        {
            NewsSettings settings = NewsCrud.ReadSettings(userId);
            NewsApiClient client = new NewsApiClient(settings);
            IEnumerable<NewsArticle> articles = client.GetNewsArticles();
            return Ok(articles);
        }
    }
}
