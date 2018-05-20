using Breakfast.Data.Models;

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
        public int GetNewsId(string userId) { return utility.GetNewsId(userId); }
        public int GetTrafficId(string userId) { return utility.GetTrafficId(userId); }
        public int GetWeatherId(string userId) { return utility.GetWeatherId(userId); }

        // Save settings
        public void SaveNewsSettings(NewsSettings ns) { utility.SaveNewsSettings(ns); }
        public void SaveTrafficSettings(TrafficSettings ts) { utility.SaveTrafficSettings(ts); }
        public void SaveWeatherSettings(WeatherSettings ws) { utility.SaveWeatherSettings(ws); }
    }
}
