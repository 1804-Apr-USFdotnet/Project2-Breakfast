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
    public class TrafficApi
    {
        public async Task<string> GetTimeToWork(TrafficSettingsBusiness tsb)
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
            string travelMode = "driving";
            if (!tsb.Driving)
            {
                travelMode = "walking";
            }
            HttpResponseMessage response = await client.GetAsync(@"https://maps.googleapis.com/maps/api/distancematrix/json?origins=place_id:" + tsb.AddressPlaceId + "&destinations=place_id:"+ tsb.WorkAddressPlaceId +"&mode=" + travelMode + "&key=" + apiKey);
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
