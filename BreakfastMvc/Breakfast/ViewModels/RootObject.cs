using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Breakfast.ViewModels
{
    public class RootObject
    {
        public string UserName { get; set; }
        public Weather Weather { get; set; }
        public Traffic Traffic { get; set; }
        public News News { get; set; }
    }
}