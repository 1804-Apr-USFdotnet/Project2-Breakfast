using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Breakfast.ViewModels
{
    public class Weather
    {
        public int id { get; set; }
        public bool enabled { get; set; }
        public bool farenheit { get; set; }
        public bool windSpeed { get; set; }
        public bool humidity { get; set; }
        public bool cloudiness { get; set; }
        public string location { get; set; }
    }
}