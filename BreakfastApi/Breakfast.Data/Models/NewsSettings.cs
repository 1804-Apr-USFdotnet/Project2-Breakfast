using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Breakfast.Data.Models
{
    public class NewsSettings
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Pk_NewsId { get; set; }
        public bool Enabled { get; set; }
        // TODO: add news specific settings

        public SettingsTable SettingsTable { get; set; }
    }
}
