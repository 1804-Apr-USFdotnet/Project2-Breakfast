using Breakfast.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Breakfast.Models
{
    public class SettingsModel
    {
        static JsonSettings jsonSettings = new JsonSettings();
        static string uri = "http://ec2-18-191-47-17.us-east-2.compute.amazonaws.com/Breakfast.Service_deploy/";
        
        public void GetSettings(string userId)
        {
            HttpWebRequest apiRequest = WebRequest.Create(uri + "api/settings/get/" + userId) as HttpWebRequest;
            string apiResponse = "";
            using (var response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }

            jsonSettings = JsonConvert.DeserializeObject<JsonSettings>(apiResponse);
        }

        public void IntializeSettings(string userId)
        {
            HttpWebRequest apiRequest = WebRequest.Create(uri + "api/settings/get/" + userId) as HttpWebRequest;
            apiRequest.ContentType = "application/json";
            apiRequest.Method = "PUT";

            using (var response = apiRequest.GetResponse() as HttpWebResponse)
            {
                 //do something with response.StatusCode
            }
        }

        public async void SaveWeatherSettings(string userId, JsonSettings.Weather weather)
        {
            string myJson = JsonConvert.SerializeObject(weather);
            using (var client = new HttpClient())
            {
                using (var response = await client.PostAsync(
                    uri + "api/settings/weather/" + userId,
                     new StringContent(myJson, Encoding.UTF8, "application/json")))
                {
                    //do something with response.StatusCode
                }
            }
        }

        public async void SaveTrafficSettings(string userId, JsonSettings.Traffic traffic)
        {
            string myJson = JsonConvert.SerializeObject(traffic);
            using (var client = new HttpClient())
            {
                using (var response = await client.PostAsync(
                    uri + "api/settings/weather/" + userId,
                     new StringContent(myJson, Encoding.UTF8, "application/json")))
                {
                    //do something with response.StatusCode
                }
            }
        }

        public async void SaveNewsSettings(string userId, JsonSettings.News news)
        {
            string myJson = JsonConvert.SerializeObject(news);
            using (var client = new HttpClient())
            {
                using (var response = await client.PostAsync(
                    uri + "api/settings/weather/" + userId,
                     new StringContent(myJson, Encoding.UTF8, "application/json")))
                {
                    //do something with response.StatusCode
                }
            }
        }
    }
}