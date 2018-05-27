using Breakfast.Areas.Weather.Models;
using Breakfast.Areas.News.Models;
using System.Collections.Generic;
using Breakfast.Areas.Traffic.Models;

namespace Breakfast.ViewModels
{
    public class Data
    {
        public RootObject settings { get; set; }
        public OpenWeatherMap weatherData { get; set; }
        public TrafficSettingsViewModel trafficData;
        public List<NewsArticle> articles { get; set; }
    }
}