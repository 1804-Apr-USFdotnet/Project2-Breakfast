using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Breakfast.ViewModels;

namespace Breakfast.Areas.Traffic.Models
{
    public class TrafficSettingsViewModel
    {
        public int Id { get; set; }
        public bool Enabled { get; set; } = true;
        public string Address { get; set; } = null;
        public string WorkAddress { get; set; } = null;  
        public bool Driving { get; set; } = true;    
        public string AddressPlaceId { get; set; } = null; 
        public string WorkAddressPlaceId { get; set; } = null;
        public double[] LatLng { get; set; }
        public string UserId { get; set; }

        //TODO: fix conversion
        //convert to domain object
        public static explicit operator TrafficSettingsViewModel(ViewModels.Traffic tsData)
        {
            TrafficSettingsViewModel trafficSettings = new TrafficSettingsViewModel()
            {
                Id = tsData.Id,
                Enabled = tsData.Enabled,
                Address = tsData.Address,
                WorkAddress = tsData.WorkAddress,
                Driving = tsData.Driving,
                AddressPlaceId = tsData.AddressPlaceId,
                WorkAddressPlaceId = tsData.WorkAddressPlaceId,
                LatLng = tsData.LatLng,
            };

            return trafficSettings;
        }

        ////convert to entity object
        public static explicit operator ViewModels.Traffic(TrafficSettingsViewModel ts)
        {
            ViewModels.Traffic tsData = new ViewModels.Traffic()
            {
                Id = ts.Id,
                Enabled = ts.Enabled,
                Address = ts.Address,
                WorkAddress = ts.WorkAddress,
                Driving = ts.Driving,
                AddressPlaceId = ts.AddressPlaceId,
                WorkAddressPlaceId = ts.WorkAddressPlaceId,
                LatLng = ts.LatLng
            };

            return tsData;
        }
    }
}