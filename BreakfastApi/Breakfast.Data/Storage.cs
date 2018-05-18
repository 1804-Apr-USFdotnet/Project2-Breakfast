using Breakfast.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakfast.Data
{
    public class Storage
    {
        private IDButils utility;
        public Storage(IDButils utility)
        {
            this.utility = utility;
        }

        // Initialize default settings on account create
        public void InitializeSettings(SettingsTable st) { utility.InitializeSettings(st); }

        // Get settings on login
        public SettingsTable GetSettings(string userId) { return utility.GetSettings(userId); }

        // Get individual settings id
        int GetNewsId(string userId) { return utility.GetNewsId(userId); }
        int GetTrafficId(string userId) { return utility.GetTrafficId(userId); }
        int GetWeatherId(string userId) { return utility.GetWeatherId(userId); }

        // Save settings
        public void SaveNewsSettings(NewsSettings ns) { utility.SaveNewsSettings(ns); }
        public void SaveTrafficSettings(TrafficSettings ts) { utility.SaveTrafficSettings(ts); }
        public void SaveWeatherSettings(WeatherSettings ws) { utility.SaveWeatherSettings(ws); }
    }
}
