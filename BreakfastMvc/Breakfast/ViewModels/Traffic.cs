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
        public object Address { get; set; }
        public object WorkAddress { get; set; }
        public bool Driving { get; set; }
        public object AddressPlaceId { get; set; }
        public object WorkAddressPlaceId { get; set; }
        public object LatLng { get; set; }
    }
}