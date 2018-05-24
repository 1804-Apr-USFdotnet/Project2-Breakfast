using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Breakfast.Business.Traffic.Models;

namespace Breakfast.Business.Traffic
{
    public static class TrafficApi
    {
        public static async Task<string> GetTimeToWork(string homePlaceId, string workPlaceId, string travelMode)
        {
            string apiKey = null;
            try
            {
                apiKey = System.IO.File.ReadAllText(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "mapskey.txt"));
            }
            catch (Exception e)
            {
                Console.WriteLine("It failed, do you have mapskey.txt in the same directory of the project");
            }
            HttpClient client = new HttpClient();
            
            HttpResponseMessage response = await client.GetAsync(@"https://maps.googleapis.com/maps/api/distancematrix/json?origins=place_id:" + homePlaceId + "&destinations=place_id:"+ workPlaceId +"&mode=" + travelMode + "&key=" + apiKey);
            string insert = null;
            if (response.IsSuccessStatusCode)
            {
                insert = await response.Content.ReadAsStringAsync();
            }

            if (insert != null)
            {
                Match match = Regex.Match(insert, "[0-9]+(?= mins)");
                if (match.Success)
                {
                    var result = match.Captures[0].Value;
                    return result;
                }
            }

            return "Unable to get your time to work";
        }

        
    }
}
