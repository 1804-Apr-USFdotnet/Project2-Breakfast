using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;

namespace Breakfast.Areas.Weather.Models
{
    public class OpenWeatherMap
    {
        public string city { get; set; }
        public string description { get; set; }
        public double windSpeed { get; set; }
        public double temperature { get; set; }
        public int humidity { get; set; }
        public int cloudiness { get; set; }
        public int visibility { get; set; }

        static public string getResponse(string zipcode)
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

            StringBuilder sb = new StringBuilder();
            sb.Append("<table><tr><th>Weather Description</th></tr>");
            sb.Append("<tr><td>City:</td><td>" + rootObject.name + "</td></tr>");
            sb.Append("<tr><td>Wind:</td><td>" + rootObject.wind.speed + " mph</td></tr>");
            sb.Append("<tr><td>Current Temperature:</td><td>" + rootObject.main.temp + " °F</td></tr>");
            sb.Append("<tr><td>Humidity:</td><td>" + rootObject.main.humidity + "%</td></tr>");
            sb.Append("<tr><td>Weather:</td><td>" + rootObject.weather[0].description + "</td></tr>");
            sb.Append("</table>");
            return sb.ToString();
        }
    }
}