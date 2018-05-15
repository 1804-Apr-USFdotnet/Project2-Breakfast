using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Breakfast.Areas.Weather.Models
{
    public class ForecastDay
    {
        public int tempMin { get; set; }
        public int tempMax { get; set; }
        public string day { get; set; }
        public string condition { get; set; }
    }
}