using System.ComponentModel.DataAnnotations.Schema;

namespace Breakfast.Data.Models
{
    class WeatherSettings
    {
        [ForeignKey("SettingsTable")]
        public int Fk_WeatherId { get; set; }
        public bool Enabled { get; set; }
        public bool Farenheit { get; set; }
        public bool WindSpeed { get; set; }
        public bool Humidity { get; set; }
        public bool Cloudiness { get; set; }
        public string Location { get; set; }

        public SettingsTable SettingsTable { get; set; }
    }
}
