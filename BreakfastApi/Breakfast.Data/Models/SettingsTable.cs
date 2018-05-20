using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Breakfast.Data.Models
{
    public class SettingsTable
    {
        [Key]
        public string Pk_Email { get; set; }

        [ForeignKey("NewsSettings")]
        public int Fk_NewsId { get; set; }

        [ForeignKey("TrafficSettings")]
        public int Fk_TrafficId { get; set; }

        [ForeignKey("WeatherSettings")]
        public int Fk_WeatherId { get; set; }

        // Eager load settings to store in cache
        public NewsSettings NewsSettings { get; set; }
        public WeatherSettings WeatherSettings { get; set; }
        public TrafficSettings TrafficSettings { get; set; }
    }
}
