using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Breakfast.Areas.Weather.Models
{
    public class ForecastDay
    {
        public double tempMin { get; set; }
        public double tempMax { get; set; }
        public string day { get; set; }
        public string icon { get; set; }
    }
}