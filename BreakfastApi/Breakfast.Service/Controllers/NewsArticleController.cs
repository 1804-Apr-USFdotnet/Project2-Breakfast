using Breakfast.Business.News.Models;
using Breakfast.Business.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;


namespace Breakfast.Service.Controllers
{
    public class NewsArticleController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(IEnumerable<NewsArticle>))]
        [Route("api/NewsArticle/{userId}")]
        public IHttpActionResult GetArticles(string userId)
        {
            //NewsSettings settings = NewsCrud.ReadSettings(userId);
            NewsSettings settings = new NewsSettings
            {
                Id = 1,
                Sources = new string[20],
                Queries = new List<string>(),
                Domains = new List<string>(),
                Language = "en",
                PageSize = 10
            };
            settings.Queries.Add("Bitcoin");
            NewsApiClient client = new NewsApiClient(settings);
            IEnumerable<NewsArticle> articles = client.GetNewsArticles();
            return Ok(articles);
        }
    }
}
