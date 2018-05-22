using Breakfast.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
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

            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                 //do something with response.StatusCode
            }
        }
    }
}