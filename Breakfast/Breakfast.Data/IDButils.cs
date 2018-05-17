using Breakfast.Data.Models;

namespace Breakfast.Data
{
    interface IDButils
    {
        // Initialize settings for new account
        void InitializeSettings(SettingsTable st);

        // Get settings
        SettingsTable GetSettings(string userId);

        // Save settings
        void SaveNewsSettings(NewsSettings ns);
        void SaveTrafficSettings(TrafficSettings ts);
        void SaveWeatherSettings(WeatherSettings ws);
    }
}
