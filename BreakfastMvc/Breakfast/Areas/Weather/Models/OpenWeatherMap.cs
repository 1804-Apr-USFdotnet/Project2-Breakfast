using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Breakfast.Areas.Weather.Models
{
    public class OpenWeatherMap
    {
        public string city { get; private set; }
        public string country { get; private set; }
        public string description { get; private set; }
        public double windSpeed { get; private set; }
        public int temperature { get; private set; }
        public char temperatureType { get; private set; } = 'F';
        public int humidity { get; private set; }
        public int cloudiness { get; private set; }
        public string condition { get; set; } = "09d";

        // 5-day forecast
        public ForecastDay[] forecastDays { get; private set; }

        public OpenWeatherMap()
        {
            forecastDays = new ForecastDay[5];
        }

        public OpenWeatherMap(string zipcode)
        {
            forecastDays = new ForecastDay[5];
            GetResponse(zipcode);
        }

        public void GetResponse(string zipcode)
        {
            string apiKey = "6e0c425a741c67ae35eda9b8812c60b8";
            HttpWebRequest apiRequest = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?zip=" + zipcode.ToString() + "&appid=" + apiKey + "&units=imperial") as HttpWebRequest;
            HttpWebRequest apiRequest2 = WebRequest.Create("http://ec2-18-188-45-20.us-east-2.compute.amazonaws.com/Breakfast.Service_deploy/" + "api/weather/get/" + zipcode) as HttpWebRequest;

            string apiResponse = "";
            string apiResponse2 = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }

            using (HttpWebResponse response2 = apiRequest2.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response2.GetResponseStream());
                apiResponse2 = reader.ReadToEnd();
            }

            JsonResponseHelpers.CurrentWeather.ResponseWeather rootObject = JsonConvert.DeserializeObject<JsonResponseHelpers.CurrentWeather.ResponseWeather>(apiResponse);

            city = rootObject.name;
            country = rootObject.sys.country;
            description = rootObject.weather[0].description;
            windSpeed = rootObject.wind.speed;
            temperature = (int)rootObject.main.temp;
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
                forecastDays[i] = new ForecastDay();

                int year, month, day;
                // Get date parts out of json date format (yyyy-mm-dd)
                Int32.TryParse(rootObject.list[i*8].dt_txt.Substring(0, 4), out year);
                Int32.TryParse(rootObject.list[i*8].dt_txt.Substring(5, 2), out month);
                Int32.TryParse(rootObject.list[i*8].dt_txt.Substring(8, 2), out day);

                DateTime dateValue = new DateTime(year, month, day);

                // Access nth day in json array, [0] = day 1, [8] = day 2, [16] = day 3, etc.
                forecastDays[i].day = dateValue.ToString("ddd");
                forecastDays[i].condition = rootObject.list[i*8].weather[0].icon;
                forecastDays[i].tempMax = (int)rootObject.list[i*8].main.temp_max;
                forecastDays[i].tempMin = (int)rootObject.list[i*8].main.temp_min;

                // Go through entire day to get max and min temperature of the day
                for (int j = 0; j < 8; j++)
                {
                    if ((i * 8 + j) >= rootObject.list.Count)
                        break;
                    if (forecastDays[i].tempMax < rootObject.list[i * 8 + j].main.temp_max)
                        forecastDays[i].tempMax = (int)rootObject.list[i * 8 + j].main.temp_max;
                    if (forecastDays[i].tempMin > rootObject.list[i * 8 + j].main.temp_min)
                        forecastDays[i].tempMin = (int)rootObject.list[i * 8 + j].main.temp_min;
                }
            }
        }
    }
}