using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Breakfast.Areas.Weather.Models
{
    public class WeatherSettings
    {
        public string city { get; set; }
        public string country { get; set; }
        public string description { get; set; }
        public double windSpeed { get; set; }
        public int temperature { get; set; }
        public char temperatureType { get; set; } = 'F';
        public int humidity { get; set; }
        public int cloudiness { get; set; }
        public string condition { get; set; } = "09d";
    }
}