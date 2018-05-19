using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Breakfast.Data.Models
{
    public class SettingsTable
    {
        [Key]
        public string Pk_Email { get; set; }

        [ForeignKey("News")]
        public int Fk_NewsId { get; set; }

        [ForeignKey("Traffic")]
        public int Fk_TrafficId { get; set; }

        [ForeignKey("Weather")]
        public int Fk_WeatherId { get; set; }

        // Eager load settings to store in cache
        public NewsSettings News { get; set; }
        public WeatherSettings Weather { get; set; }
        public TrafficSettings Traffic { get; set; }
    }
}
