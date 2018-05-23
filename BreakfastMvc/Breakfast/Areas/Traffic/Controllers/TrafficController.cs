using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Breakfast.Areas.Traffic.Models;
using Breakfast.Models;
using Breakfast.ViewModels;

//using Breakfast.Data;

namespace Breakfast.Areas.Traffic.Controllers
{
    public class TrafficController : AsyncController
    {
        private static string apiKey = null;
         

        public TrafficController()
        {
            setApiKey();
        }
        // GET: Traffic/Traffic
        public async Task<ActionResult> ViewMap(string userId)
        {
            SettingsModel settingsModel = new SettingsModel();
            settingsModel.GetSettings(userId);
            JsonSettings.RootObject jsonSettings = settingsModel.GetJson();
            TrafficSettingsViewModel tsvm = new TrafficSettingsViewModel();
            tsvm = (TrafficSettingsViewModel)jsonSettings.Traffic;
            

            
            ViewBag.TimeToWork = "Not sure";
            ViewBag.Address = tsvm.Address;
            ViewBag.WorkAddress = tsvm.WorkAddress;
            ViewBag.APIKey = apiKey;
            return View();
        }

        public ActionResult Settings(string userId)
        {
            
           
            SettingsModel settingsModel = new SettingsModel();
            settingsModel.GetSettings(userId);
            JsonSettings.RootObject jsonSettings = settingsModel.GetJson();
            TrafficSettingsViewModel tsvm = new TrafficSettingsViewModel();
            tsvm = (TrafficSettingsViewModel)jsonSettings.Traffic;
            ViewBag.APIKey = apiKey;
            ViewBag.Address = tsvm.Address;
            ViewBag.WorkAddress = tsvm.WorkAddress;
            ViewBag.ZoomLevel = 12;
            
            return View(tsvm);
        }

        private void setApiKey()
        {
            try
            {
                apiKey = System.IO.File.ReadAllText(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "mapskey.txt"));
            }
            catch (Exception e)
            {
                Console.WriteLine("Shit failed");
            }
        }
        [HttpPost]
        public ActionResult SaveSettings(TrafficSettingsViewModel ts)
        {
            //TODO: Fix data access
            //Storage storage = new Storage(new DefaultDBUtils());
            //storage.SaveTrafficSettings((Data.Models.TrafficSettings)ts);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}