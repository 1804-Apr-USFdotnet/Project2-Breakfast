using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Breakfast.ViewModels
{
    public class Traffic
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public string Address { get; set; }
        public string WorkAddress { get; set; }
        public bool Driving { get; set; }
        public string AddressPlaceId { get; set; }
        public string WorkAddressPlaceId { get; set; }
        public double[] LatLng { get; set; }
    }
}