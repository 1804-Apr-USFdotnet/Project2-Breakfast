using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Breakfast.Data.Models
{
    public class WeatherSettings
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Pk_WeatherId { get; set; }
        public bool Enabled { get; set; }
        public bool Farenheit { get; set; }
        public bool WindSpeed { get; set; }
        public bool Humidity { get; set; }
        public bool Cloudiness { get; set; }
        public string Location { get; set; }
    }
}
