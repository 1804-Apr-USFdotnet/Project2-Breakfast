using System.ComponentModel.DataAnnotations.Schema;

namespace Breakfast.Data.Models
{
    public class NewsSettings
    {
        [ForeignKey("SettingsTable")]
        public int Fk_NewsId { get; set; }
        public bool Enabled { get; set; }
        // TODO: add news specific settings

        public SettingsTable SettingsTable { get; set; }
    }
}
