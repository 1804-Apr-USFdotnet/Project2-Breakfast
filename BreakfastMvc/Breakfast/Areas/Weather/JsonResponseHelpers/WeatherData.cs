using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Breakfast.Areas.Weather.JsonResponseHelpers
{
    public class WeatherData
    {
        public class ForecastDay
        {
            public int tempMin { get; set; }
            public int tempMax { get; set; }
            public string day { get; set; }
            public string condition { get; set; }
        }

        public class RootObject
        {
            public string city { get; set; }
            public string country { get; set; }
            public string description { get; set; }
            public double windSpeed { get; set; }
            public int temperature { get; set; }
            public string temperatureType { get; set; }
            public int humidity { get; set; }
            public int cloudiness { get; set; }
            public string condition { get; set; }
            public List<ForecastDay> forecastDays { get; set; }
        }
    }
}