using Breakfast.Data;
using Breakfast.Business.Weather.Models;

namespace Breakfast.Business.Weather
{
    static public class WeatherCrud
    {
        static public void SaveSettings(string userId, WeatherSettings cw)
        {
            Storage storage = new Storage(new DefaultDBUtils());
            cw.id = storage.GetWeatherId(userId);
            storage.SaveWeatherSettings((Data.Models.WeatherSettings)cw);
        }
    }
}
