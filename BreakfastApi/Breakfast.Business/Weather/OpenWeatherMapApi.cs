using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace Breakfast.Business.Weather
{
    static public class OpenWeatherMapApi
    {
        static public string GetResponse(string zipcode)
        {
            string apiKey = "6e0c425a741c67ae35eda9b8812c60b8";
            HttpWebRequest apiRequest = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?zip=" + zipcode.ToString() + "&appid=" + apiKey + "&units=imperial") as HttpWebRequest;

            string apiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }
            return apiResponse;
        }
        //public Models.CurrentWeather GetResponse(string zipcode)
        //{
        //    string apiKey = "6e0c425a741c67ae35eda9b8812c60b8";
        //    HttpWebRequest apiRequest = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?zip=" + zipcode.ToString() + "&appid=" + apiKey + "&units=imperial") as HttpWebRequest;

        //    string apiResponse = "";
        //    using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
        //    {
        //        StreamReader reader = new StreamReader(response.GetResponseStream());
        //        apiResponse = reader.ReadToEnd();
        //    }

        //    Models.JsonCurrentWeather.ResponseWeather rootObject = JsonConvert.DeserializeObject<Models.JsonCurrentWeather.ResponseWeather>(apiResponse);

        //    Models.CurrentWeather currentWeather = new Models.CurrentWeather()
        //    {
        //        city = rootObject.name,
        //        country = rootObject.sys.country,
        //        description = rootObject.weather[0].description,
        //        windSpeed = rootObject.wind.speed,
        //        temperature = (int)rootObject.main.temp,
        //        humidity = rootObject.main.humidity,
        //        cloudiness = rootObject.clouds.all,
        //        condition = rootObject.weather[0].icon,
        //        forecastDays = new Models.ForecastWeather[5]
        //    };

        //    Models.ForecastWeather[] forecasts = new Models.ForecastWeather[5];
        //    GetForecast(zipcode, ref forecasts);
        //    currentWeather.forecastDays = forecasts;

        //    return currentWeather;
        //}

        //private void GetForecast(string zipcode, ref Models.ForecastWeather[] days)
        //{
        //    string apiKey = "6e0c425a741c67ae35eda9b8812c60b8";
        //    HttpWebRequest apiRequest = WebRequest.Create("http://api.openweathermap.org/data/2.5/forecast?zip=" + zipcode.ToString() + "&appid=" + apiKey + "&units=imperial") as HttpWebRequest;

        //    string apiResponse = "";
        //    using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
        //    {
        //        StreamReader reader = new StreamReader(response.GetResponseStream());
        //        apiResponse = reader.ReadToEnd();
        //    }

        //    Models.JsonForecastWeather.ResponseWeather rootObject = JsonConvert.DeserializeObject<Models.JsonForecastWeather.ResponseWeather>(apiResponse);

        //    for (int i = 0; i < 5; i++)
        //    {
        //        days[i] = new Models.ForecastWeather();

        //        int year, month, day;
        //        // Get date parts out of json date format (yyyy-mm-dd)
        //        Int32.TryParse(rootObject.list[i * 8].dt_txt.Substring(0, 4), out year);
        //        Int32.TryParse(rootObject.list[i * 8].dt_txt.Substring(5, 2), out month);
        //        Int32.TryParse(rootObject.list[i * 8].dt_txt.Substring(8, 2), out day);

        //        DateTime dateValue = new DateTime(year, month, day);

        //        // Access nth day in json array, [0] = day 1, [8] = day 2, [16] = day 3, etc.
        //        days[i].day = dateValue.ToString("ddd");
        //        days[i].condition = rootObject.list[i * 8].weather[0].icon;
        //        days[i].tempMax = (int)rootObject.list[i * 8].main.temp_max;
        //        days[i].tempMin = (int)rootObject.list[i * 8].main.temp_min;

        //        // Go through entire day to get max and min temperature of the day
        //        for (int j = 0; j < 8; j++)
        //        {
        //            if (days[i].tempMax < rootObject.list[i * 8 + j].main.temp_max)
        //                days[i].tempMax = (int)rootObject.list[i * 8 + j].main.temp_max;
        //            if (days[i].tempMin > rootObject.list[i * 8 + j].main.temp_min)
        //                days[i].tempMin = (int)rootObject.list[i * 8 + j].main.temp_min;
        //        }
        //    }
        //}
    }
}
