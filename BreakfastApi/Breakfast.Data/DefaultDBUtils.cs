using System;
using System.Data.Entity;
using System.Linq;
using Breakfast.Data.Models;

namespace Breakfast.Data
{
    public class DefaultDBUtils : IDButils
    {

        /* * * * * * * * * * * * * * * * * * * * * * * * * * *
         * 
         *          Create/get all settings section
         *            
         * * * * * * * * * * * * * * * * * * * * * * * * * * */

        public void InitializeSettings(SettingsTable st)
        {
            try
            {
                using (var db = new DefaultContext())
                {
                    db.SettingsTable.Add(st);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SettingsTable GetSettings(string userId)
        {
            using (var db = new DefaultContext())
            {
                SettingsTable st = db.SettingsTable
                                     .Include(x => x.WeatherSettings)
                                     .Include(x => x.NewsSettings)
                                     .Include(x => x.TrafficSettings)
                                     .SingleOrDefault(x => x.Pk_Email == userId);
                return st;
            }
        }

        /* * * * * * * * * * * * * * * * * * * * * * * * * * *
         * 
         *          Get individual settings id section
         *            
         * * * * * * * * * * * * * * * * * * * * * * * * * * */

        public int GetNewsId(string userId)
        {
            using (var db = new DefaultContext())
                return db.SettingsTable.SingleOrDefault(x => x.Pk_Email == userId).Fk_NewsId;
        }

        public int GetTrafficId(string userId)
        {
            using (var db = new DefaultContext())
                return db.SettingsTable.SingleOrDefault(x => x.Pk_Email == userId).Fk_TrafficId;
        }

        public int GetWeatherId(string userId)
        {
            using (var db = new DefaultContext())
                return db.SettingsTable.SingleOrDefault(x => x.Pk_Email == userId).Fk_WeatherId;
        }

        /* * * * * * * * * * * * * * * * * * * * * * * * * * *
         * 
         *          Save individual settings section
         *            
         * * * * * * * * * * * * * * * * * * * * * * * * * * */

        public void SaveNewsSettings(NewsSettings ns)
        {
            using (var db = new DefaultContext())
            {
                NewsSettings currentNewsSettings = db.NewsSettings.SingleOrDefault(x => x.Pk_NewsId == ns.Pk_NewsId);
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
                TrafficSettings currentTrafficSettings = db.TrafficSettings.SingleOrDefault(x => x.Pk_TrafficId == ts.Pk_TrafficId);
                currentTrafficSettings.Enabled = ts.Enabled;
                currentTrafficSettings.Address = ts.Address;
                currentTrafficSettings.WorkAddress = ts.WorkAddress;
                currentTrafficSettings.Driving = ts.Driving;
                currentTrafficSettings.AddressPlaceId = ts.AddressPlaceId;
                currentTrafficSettings.WorkAddressPlaceId = ts.WorkAddressPlaceId;
                currentTrafficSettings.LatLng = ts.LatLng;
                

                db.TrafficSettings.Attach(currentTrafficSettings);
                db.Entry(currentTrafficSettings).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void SaveWeatherSettings(WeatherSettings ws)
        {
            using (var db = new DefaultContext())
            {
                WeatherSettings currentWeatherSettings = db.WeatherSettings.SingleOrDefault(x => x.Pk_WeatherId == ws.Pk_WeatherId);
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
