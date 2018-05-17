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

        void InitializeSettings(SettingsTable st) { utility.InitializeSettings(st); }

        // Get settings
        SettingsTable GetSettings(string userId) { return utility.GetSettings(userId); }

        // Save settings
        void SaveNewsSettings(NewsSettings ns) { utility.SaveNewsSettings(ns); }
        void SaveTrafficSettings(TrafficSettings ts) { utility.SaveTrafficSettings(ts); }
        void SaveWeatherSettings(WeatherSettings ws) { utility.SaveWeatherSettings(ws); }
    }
}
