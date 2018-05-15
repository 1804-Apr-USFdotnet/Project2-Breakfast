using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;

namespace Breakfast.Areas.Weather.Models
{
    public class OpenWeatherMap
    {
        public string city { get; set; }
        public string country { get; set; }
        public string description { get; set; }
        public double windSpeed { get; set; }
        public double temperature { get; set; }
        public char temperatureType { get; set; } = 'F';
        public int humidity { get; set; }
        public int cloudiness { get; set; }
        public string condition { get; set; } = "09d";

        // 5-day forecast
        public ForecastDay[] forecastDays = new ForecastDay[5];

        public OpenWeatherMap()
        {
            
        }

        public OpenWeatherMap(string zipcode)
        {
            GetResponse(zipcode);
        }

        public void GetResponse(string zipcode)
        {
            string apiKey = "6e0c425a741c67ae35eda9b8812c60b8";
            HttpWebRequest apiRequest = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?zip=" + zipcode.ToString() + "&appid=" + apiKey + "&units=imperial") as HttpWebRequest;
           
            string apiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }

            JsonResponseHelpers.CurrentWeather.ResponseWeather rootObject = JsonConvert.DeserializeObject<JsonResponseHelpers.CurrentWeather.ResponseWeather>(apiResponse);

            city = rootObject.name;
            country = rootObject.sys.country;
            description = rootObject.weather[0].description;
            windSpeed = rootObject.wind.speed;
            temperature = rootObject.main.temp;
            humidity = rootObject.main.humidity;
            cloudiness = rootObject.clouds.all;
            condition = rootObject.weather[0].icon;

            GetForecast(zipcode);
        }

        private void GetForecast(string zipcode)
        {
            string apiKey = "6e0c425a741c67ae35eda9b8812c60b8";
            HttpWebRequest apiRequest = WebRequest.Create("http://api.openweathermap.org/data/2.5/forecast?zip=" + zipcode.ToString() + "&appid=" + apiKey + "&units=imperial") as HttpWebRequest;

            string apiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }

            JsonResponseHelpers.ForecastWeather.ResponseWeather rootObject = JsonConvert.DeserializeObject<JsonResponseHelpers.ForecastWeather.ResponseWeather>(apiResponse);

            for (int i = 0; i < 5; i++)
            {
                forecastDays[i].condition = rootObject.list[i * 8].weather[0].icon;
                forecastDays[i].day = rootObject.list[i * 8].dt.ToString();
                forecastDays[i].tempMax = rootObject.list[i * 8].main.temp_max;
                forecastDays[i].tempMin = rootObject.list[i * 8].main.temp_min;
            }
        }
    }
}