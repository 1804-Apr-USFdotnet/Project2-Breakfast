using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakfast.Business.Weather.Models
{
    public class ForecastWeather
    {
        public int tempMin { get; set; }
        public int tempMax { get; set; }
        public string day { get; set; }
        public string condition { get; set; }
    }
}
