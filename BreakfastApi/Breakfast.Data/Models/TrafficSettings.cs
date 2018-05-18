using System.ComponentModel.DataAnnotations.Schema;

namespace Breakfast.Data.Models
{
    public class TrafficSettings
    {
        [ForeignKey("SettingsTable")]
        public int Fk_TrafficId { get; set; }
        public bool Enabled { get; set; }
        public string Address { get; set; }
        public string WorkAddress { get; set; }
        public string TravelMode { get; set; }
        public string AddressPlaceId { get; set; }
        public string WorkAddressPlaceId { get; set; }
        public double[] LatLng { get; set; }

        public SettingsTable SettingsTable { get; set; }
    }
}
