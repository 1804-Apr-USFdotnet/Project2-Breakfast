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
        public string Queries { get; set; }
        public string Sources { get; set; }// questioning implementation here
        public string Domains { get; set; }
        public Nullable<DateTime> OldestDate { get; set; }
        public Nullable<DateTime> NewestDate { get; set; }
        public string Language { get; set; }
        public Nullable<int> PageSize { get; set; }
    }
}
