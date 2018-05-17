using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Breakfast.Areas.Traffic.Controllers
{
    public class TrafficController : AsyncController
    {
        // GET: Traffic/Traffic
        public async Task<ActionResult> ViewMap()
        {
            string apiKey = null;
            try
            {
                apiKey = System.IO.File.ReadAllText(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "mapskey.txt"));
            }
            catch (Exception e)
            {
                Console.WriteLine("Shit failed");
            }
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(@"https://maps.googleapis.com/maps/api/distancematrix/json?origins=Bellarmine+Newman+Hall&destinations=MacDintons+SoHo&mode=driving&key=AIzaSyD0FSkqNKs7dZ30P_yDVwmFQglHpazFCgQ=");
            string insert = null;
            if (response.IsSuccessStatusCode)
            {
               insert = await response.Content.ReadAsStringAsync();
            }

            Match match = Regex.Match(insert, "[0-9]+(?= mins)");
            if (match.Success)
            {
                var result = match.Captures[0].Value;
                ViewBag.TimeToWork = result;
            }

            int minuteIndex = insert.IndexOf("mins");
            ViewBag.Insert = insert;
            ViewBag.Address = "Bellarmine Newman Hall";
            ViewBag.WorkAddress = "Tampa, FL";
            ViewBag.APIKey = apiKey;
            return View();
        }
    }
}