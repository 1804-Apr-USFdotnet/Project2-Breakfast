using Breakfast.Business.Traffic.Models;
using Breakfast.Business.Weather.Models;
using Breakfast.Business.News.Models;

namespace Breakfast.Business
{
    public class SettingsModel
    {
        public string UserEmail { get; set; }
        public WeatherSettings Weather { get; set; }
        public TrafficSettingsBusiness Traffic { get; set; }
        public NewsSettings News { get; set; }
        

        static public explicit operator SettingsModel(Data.Models.SettingsTable settingsTable)
        {
            SettingsModel settingsModel = new SettingsModel()
            {
                UserEmail = settingsTable.Pk_Email,
                Weather = (WeatherSettings)settingsTable.WeatherSettings,
                Traffic = (TrafficSettingsBusiness)settingsTable.TrafficSettings,
                News = (NewsSettings)settingsTable.NewsSettings
            };

            return settingsModel;
        }
    }
}
