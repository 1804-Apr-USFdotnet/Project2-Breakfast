using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Breakfast.Data.Models
{
    public class SettingsTable
    {
        [Required]
        public string Fk_Email { get; set; }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Pk_NewsId { get; set; }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Pk_TrafficId { get; set; }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Pk_WeatherId { get; set; }

        // Eager load settings to store in cache
        public NewsSettings News { get; set; }
        public WeatherSettings Weather { get; set; }
        public TrafficSettings Traffic { get; set; }
    }
}
