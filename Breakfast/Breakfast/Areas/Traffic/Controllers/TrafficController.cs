using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Breakfast.Areas.Traffic.Controllers
{
    public class TrafficController : Controller
    {
        // GET: Traffic/Traffic
        public ActionResult ViewMap()
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

            ViewBag.APIKey = apiKey;
            return View();
        }
    }
}