using Breakfast.ViewModels;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Breakfast.Models
{
    public class SettingsModel
    {
        static string uri = "http://ec2-18-188-45-20.us-east-2.compute.amazonaws.com/Breakfast.Service_deploy/";
        static RootObject jsonSettings = new RootObject();

        public RootObject GetSettings(string userId)
        {
            HttpWebRequest apiRequest = WebRequest.Create(uri + "api/settings/get/" + userId + "/") as HttpWebRequest;
            string apiResponse = "";
            using (var response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }

            jsonSettings = JsonConvert.DeserializeObject<RootObject>(apiResponse);
            return jsonSettings;
        }

        public void InitializeSettings(string userId)
        {
            HttpWebRequest apiRequest = WebRequest.Create(uri + "api/settings/initialize/" + userId + "/") as HttpWebRequest;
            using (var response = apiRequest.GetResponse() as HttpWebResponse)
            {
                //do something with response.StatusCode
                Debug.WriteLine(response.StatusCode);
                Debug.WriteLine(response.StatusDescription);
            }
        }

        public void InitializeSettings(string userId, string homeAddress, string workAddress)
        {
            HttpWebRequest apiRequest = WebRequest.Create(uri + "api/settings/initialize/" + userId + "/" + homeAddress + "/" + workAddress + "/") as HttpWebRequest;
            using (var response = apiRequest.GetResponse() as HttpWebResponse)
            {
                //do something with response.StatusCode
                Debug.WriteLine(response.StatusCode);
                Debug.WriteLine(response.StatusDescription);
            }
        }

        public async Task<HttpResponseMessage> SaveWeatherSettings(string userId, Weather weather)
        {
            AppDbContext db = new AppDbContext();
            AppUser currentUser = db.Users.FirstOrDefault(x => x.UserName == userId);
            weather.location = currentUser.zipcode;
            string myJson = JsonConvert.SerializeObject(weather);
            using (var client = new HttpClient())
            {
                using (var response = await client.PostAsync(
                    uri + "api/settings/weather/" + userId,
                     new StringContent(myJson, Encoding.UTF8, "application/json")))
                {
                    //do something with response.StatusCode
                    Debug.WriteLine(response.StatusCode);
                    Debug.WriteLine(response.ReasonPhrase);
                    return response;
                }
            }
        }

        public async Task<HttpResponseMessage> SaveTrafficSettings(string userId, Traffic traffic)
        {
            string myJson = JsonConvert.SerializeObject(traffic);
            using (var client = new HttpClient())
            {
                using (var response = await client.PostAsync(
                    uri + "api/settings/traffic/" + userId,
                     new StringContent(myJson, Encoding.UTF8, "application/json")))
                {
                    //do something with response.StatusCode
                    Debug.WriteLine(response.StatusCode);
                    Debug.WriteLine(response.ReasonPhrase);
                    return response;
                }
            }
        }

        public async Task<HttpResponseMessage> SaveNewsSettings(string userId, News news)
        {
            AppDbContext db = new AppDbContext();
            AppUser user = db.Users.FirstOrDefault(x => x.Id == userId);

            string myJson = JsonConvert.SerializeObject(news);
            using (var client = new HttpClient())
            {
                using (var response = await client.PostAsync(
                    uri + "api/settings/news/" + userId,
                     new StringContent(myJson, Encoding.UTF8, "application/json")))
                {
                    //do something with response.StatusCode
                    Debug.WriteLine(response.StatusCode);
                    Debug.WriteLine(response.ReasonPhrase);

                    return response;
                }
            }
        }
    }
}