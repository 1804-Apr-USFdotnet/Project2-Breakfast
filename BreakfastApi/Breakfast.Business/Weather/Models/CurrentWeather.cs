namespace Breakfast.Business.Weather.Models
{
    public class CurrentWeather
    {
        public string city { get; set; }
        public string country { get; set; }
        public string description { get; set; }
        public double windSpeed { get; set; }
        public int temperature { get; set; }
        public char temperatureType { get; set; } = 'F';
        public int humidity { get; set; }
        public int cloudiness { get; set; }
        public string condition { get; set; } = "09d";
        public ForecastWeather[] forecastDays { get; set; }
    }
}
