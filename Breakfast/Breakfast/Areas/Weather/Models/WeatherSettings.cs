using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Breakfast.Areas.Weather.Models
{
    public class WeatherSettings
    {
        public bool enabled { get; set; } = true;
        public bool farenheit { get; set; } = true;
        public bool windSpeed { get; set; } = false;  //rootObject.wind.speed
        public bool humidity { get; set; } = true;    //rootObject.main.humidity
        public bool cloudiness { get; set; } = false; //rootObject.clouds.all
        public string location { get; set; }
    }
}