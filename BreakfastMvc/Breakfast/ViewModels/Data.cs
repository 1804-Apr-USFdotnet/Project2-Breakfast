using Breakfast.Areas.Weather.Models;

namespace Breakfast.ViewModels
{
    public class Data
    {
        public JsonSettings.RootObject settings { get; set; }
        public OpenWeatherMap weatherData { get; set; }
        //TODO: add news data object, traffic data object
    }
}