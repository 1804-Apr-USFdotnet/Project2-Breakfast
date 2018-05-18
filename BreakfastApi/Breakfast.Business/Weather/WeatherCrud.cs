using Breakfast.Data;
using Breakfast.Business.Weather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakfast.Business.Weather
{
    public class WeatherCrud
    {
        public void SaveSettings(string userId, WeatherSettings cw)
        {
            Storage storage = new Storage(new DefaultDBUtils());
            cw.id = storage.GetWeatherId(userId);
            storage.SaveWeatherSettings((Data.Models.WeatherSettings)cw);
        }
    }
}
