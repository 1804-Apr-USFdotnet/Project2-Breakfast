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
            HttpWebRequest apiRequest = WebRequest.Create("http://ec2-18-188-45-20.us-east-2.compute.amazonaws.com/Breakfast.Service_deploy/" + "api/weather/get/" + zipcode) as HttpWebRequest;

            string apiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }

            JsonResponseHelpers.WeatherData.RootObject rootObject = JsonConvert.DeserializeObject<JsonResponseHelpers.WeatherData.RootObject>(apiResponse);

            city = rootObject.city;
            country = rootObject.country;
            description = rootObject.description;
            windSpeed = rootObject.windSpeed;
            temperature = rootObject.temperature;
            humidity = rootObject.humidity;
            cloudiness = rootObject.cloudiness;
            condition = rootObject.condition;

            int curr = 0;
            foreach (var item in rootObject.forecastDays)
            {
                if (curr < 5)
                    forecastDays[curr] = new ForecastDay
                    {
                        condition = item.condition,
                        day = item.day,
                        tempMax = item.tempMax,
                        tempMin = item.tempMin
                    };
                curr++;
            }
        }
    }
}