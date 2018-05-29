using System;
using System.Collections.Generic;
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
        public object Language { get; set; }
        public object PageSize { get; set; }
        public string OldestDate { get; set; }
        public string NewestDate { get; set; }
    }
}