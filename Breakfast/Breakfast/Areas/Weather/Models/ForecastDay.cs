using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Breakfast.Areas.Weather.Models
{
    public class ForecastDay
    {
        string day { get; set; }
        double tempMin { get; set; }
        double tempMax { get; set; }
    }
}