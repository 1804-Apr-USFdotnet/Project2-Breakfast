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
            RootObject jsonSettings = settingsModel.GetSettings(userId);
            TrafficSettingsViewModel tsvm = new TrafficSettingsViewModel();
            tsvm = (TrafficSettingsViewModel)jsonSettings.Traffic;

            string timeToWork = await TrafficSettingsViewModel.SetTimeToWork(tsvm);
            string travelMode = (tsvm.Driving) ? "DRIVING" : "WALKING";

            ViewBag.TimeToWork = timeToWork;
            ViewBag.TravelMode = travelMode;
            ViewBag.Address = tsvm.Address;
            ViewBag.WorkAddress = tsvm.WorkAddress;
            ViewBag.APIKey = apiKey;
            return View();
        }

        public ActionResult Settings(string userId)
        {
            SettingsModel settingsModel = new SettingsModel();
            RootObject jsonSettings = settingsModel.GetSettings(userId);
            TrafficSettingsViewModel tsvm = new TrafficSettingsViewModel();
            tsvm = (TrafficSettingsViewModel)jsonSettings.Traffic;
            tsvm.UserId = userId;
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
        public async Task<ActionResult> SaveSettings(TrafficSettingsViewModel ts)
        {
            
            SettingsModel settingsModel = new SettingsModel();
            
            ViewModels.Traffic jsonSettingsTraffic = (ViewModels.Traffic)ts;
            var response = await settingsModel.SaveTrafficSettings(ts.UserId, jsonSettingsTraffic);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}