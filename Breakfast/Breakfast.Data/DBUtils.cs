using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Breakfast.Data.Models;

namespace Breakfast.Data
{
    class DBUtils : IDButils
    {
        private IContext db;
        public DBUtils(IContext db)
        {
            this.db = db;
        }

        public SettingsTable GetSettings(string userId)
        {
            return db.SettingsTable.SingleOrDefault(x => x.Fk_Email == userId);
        }

        public void SaveNewsSettings(NewsSettings ns)
        {
            throw new NotImplementedException();
        }

        public void SaveTrafficSettings(TrafficSettings ts)
        {
            throw new NotImplementedException();
        }

        public void SaveWeatherSettings(WeatherSettings ws)
        {
            throw new NotImplementedException();
        }
    }
}
