using System;
using System.Data.Entity;
using System.Linq;
using Breakfast.Data.Models;

namespace Breakfast.Data
{
    class DefaultDBUtils : IDButils
    {
        public void InitializeSettings(SettingsTable st)
        {
            using (var db = new DefaultContext())
                db.SettingsTable.Add(st);
        }

        public SettingsTable GetSettings(string userId)
        {
            using (var db = new DefaultContext())
                return db.SettingsTable.SingleOrDefault(x => x.Fk_Email == userId);
        }

        public void SaveNewsSettings(NewsSettings ns)
        {
            using (var db = new DefaultContext())
            {
                NewsSettings currentNewsSettings = db.NewsSettings.SingleOrDefault(x => x.Fk_NewsId == ns.Fk_NewsId);
                currentNewsSettings.Enabled = ns.Enabled;
                // TODO: add other settings

                db.NewsSettings.Attach(currentNewsSettings);
                db.Entry(currentNewsSettings).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void SaveTrafficSettings(TrafficSettings ts)
        {
            using (var db = new DefaultContext())
            {
                TrafficSettings currentTrafficSettings = db.TrafficSettings.SingleOrDefault(x => x.Fk_TrafficId == ts.Fk_TrafficId);
                currentTrafficSettings.Enabled = ts.Enabled;
                // TODO: add other settings

                db.TrafficSettings.Attach(currentTrafficSettings);
                db.Entry(currentTrafficSettings).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void SaveWeatherSettings(WeatherSettings ws)
        {
            using (var db = new DefaultContext())
            {
                WeatherSettings currentWeatherSettings = db.WeatherSettings.SingleOrDefault(x => x.Fk_WeatherId == ws.Fk_WeatherId);
                currentWeatherSettings.Enabled = ws.Enabled;
                currentWeatherSettings.Farenheit = ws.Farenheit;
                currentWeatherSettings.Cloudiness = ws.Cloudiness;
                currentWeatherSettings.Humidity = ws.Humidity;
                currentWeatherSettings.WindSpeed = ws.WindSpeed;
                currentWeatherSettings.Location = ws.Location;

                db.WeatherSettings.Attach(currentWeatherSettings);
                db.Entry(currentWeatherSettings).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
