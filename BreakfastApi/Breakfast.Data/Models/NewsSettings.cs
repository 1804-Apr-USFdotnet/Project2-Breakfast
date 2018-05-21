using System;
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

        public string QueryStrings;
        public string Sources; // questioning implementation here
        public string Domains;
        private Nullable<DateTime> _OldestDate;
        private Nullable<DateTime> _NewestDate;
        public string Language;
        public Nullable<int> PageSize;
    }
}
