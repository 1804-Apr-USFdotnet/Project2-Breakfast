using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakfast.Business.Weather.Models
{
    class CurrentWeather
    {
        public string city { get; private set; }
        public string country { get; private set; }
        public string description { get; private set; }
        public double windSpeed { get; private set; }
        public int temperature { get; private set; }
        public char temperatureType { get; private set; } = 'F';
        public int humidity { get; private set; }
        public int cloudiness { get; private set; }
        public string condition { get; set; } = "09d";
    }
}
