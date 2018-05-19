using Breakfast.Business.Weather.Models;

namespace Breakfast.Business
{
    public class SettingsModel
    {
        public string UserEmail { get; set; }
        public WeatherSettings Weather { get; set; }
        //TODO: create and add domain objects for traffic and news settings like above line
        //Example 1: public NewsSettings News { get; set; }
        //Example 2: public TrafficSettings Traffic { get; get; }

        static public explicit operator SettingsModel(Data.Models.SettingsTable settingsTable)
        {
            SettingsModel settingsModel = new SettingsModel()
            {
                UserEmail = settingsTable.Fk_Email,
                Weather = (WeatherSettings)settingsTable.Weather
                //TODO: convert traffic/news entity models to domain model like above line
                //Example 1: News = (NewsSettings)settingsTable.News
                //Example 2: Traffic = (TrafficSettings)settingsTable.Traffic
                //See /Weather/Models/WeatherSettings.cs for conversion example to allow casting
            };

            return settingsModel;
        }
    }
}
