using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Breakfast.Areas.Weather.Models
{
    public class OpenWeatherMap
    {
        public WeatherSettings weatherSettings { get; set; }
        public ForecastDay[] forecastDays { get; set; }

        public OpenWeatherMap()
        {
            forecastDays = new ForecastDay[5];
            weatherSettings = new WeatherSettings();
        }

        public OpenWeatherMap(string zipcode)
        {
            forecastDays = new ForecastDay[5];
            weatherSettings = new WeatherSettings();
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

            weatherSettings.city = rootObject.city;
            weatherSettings.country = rootObject.country;
            weatherSettings.description = rootObject.description;
            weatherSettings.windSpeed = rootObject.windSpeed;
            weatherSettings.temperature = rootObject.temperature;
            weatherSettings.humidity = rootObject.humidity;
            weatherSettings.cloudiness = rootObject.cloudiness;
            weatherSettings.condition = rootObject.condition;

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