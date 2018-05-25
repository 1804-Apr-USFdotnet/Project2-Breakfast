using Breakfast.Areas.Weather.Models;
using Breakfast.Areas.News.Models;
using System.Collections.Generic;

namespace Breakfast.ViewModels
{
    public class Data
    {
        public RootObject settings { get; set; }
        public OpenWeatherMap weatherData { get; set; }
        //TODO: add news data object, traffic data object
        public List<NewsArticle> articles { get; set; }
    }
}