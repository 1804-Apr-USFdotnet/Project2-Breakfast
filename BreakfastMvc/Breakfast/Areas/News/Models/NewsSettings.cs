using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Breakfast.Areas.News.Models
{
    public class NewsSettings
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public string Domains { get; set; }
        public string Queries { get; set; }
        public string Sources { get; set; }
        public DateTime OldestDate { get; set; }
        public DateTime NewestDate { get; set; }
        public string Language { get; set; }
        public int PageSize { get; set; }
    }
}