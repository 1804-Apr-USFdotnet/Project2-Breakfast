using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakfast.Data
{
    interface IContext
    {
        DbSet<Models.SettingsTable> SettingsTable { get; set; }
        DbSet<Models.NewsSettings> NewsSettings { get; set; }
        DbSet<Models.TrafficSettings> TrafficSettings { get; set; }
        DbSet<Models.WeatherSettings> WeatherSettings { get; set; }
    }
}
