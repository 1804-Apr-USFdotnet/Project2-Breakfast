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
        string uri = "http://ec2-18-191-47-17.us-east-2.compute.amazonaws.com/Breakfast.Service_deploy/";
        
        public void GetSettings(string userId)
        {
            HttpWebRequest apiRequest = WebRequest.Create(uri + "api/settings/get/" + userId) as HttpWebRequest;
            string apiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }
        }
    }
}