using System.ComponentModel.DataAnnotations.Schema;

namespace Breakfast.Data.Models
{
    public class TrafficSettings
    {
        [ForeignKey("SettingsTable")]
        public int Fk_TrafficId { get; set; }
        public bool Enabled { get; set; }
        // TODO: add traffic specific settings

        public SettingsTable SettingsTable { get; set; }
    }
}
