using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Breakfast.ViewModels
{
    public class News
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public string Queries { get; set; }
        public string Sources { get; set; }
        public string Domains { get; set; }
        public string Language { get; set; }
        [RegularExpression(@"\d+")]
        public string PageSize { get; set; }
        [DataType(DataType.Date)]
        public Nullable<DateTime> OldestDate { get; set; }
        [DataType(DataType.Date)]
        public Nullable<DateTime> NewestDate { get; set; }
    }
}