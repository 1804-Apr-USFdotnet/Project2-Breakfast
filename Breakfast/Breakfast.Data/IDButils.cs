using Breakfast.Data.Models;

namespace Breakfast.Data
{
    interface IDButils
    {
        // Get settings
        SettingsTable GetSettings(string userId);

        // Save settings
        void SaveNewsSettings(NewsSettings ns);
        void SaveTrafficSettings(TrafficSettings ts);
        void SaveWeatherSettings(WeatherSettings ws);
    }
}
