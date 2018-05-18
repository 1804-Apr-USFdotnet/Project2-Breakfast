using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Breakfast.Areas.Traffic.Models
{
    public class TrafficSettingsViewModel
    {
        public int Id { get; set; }
        public bool Enabled { get; set; } = true;
        public string Address { get; set; } = null;
        public string WorkAddress { get; set; } = null;  //rootObject.wind.speed
        public string TravelMode { get; set; } = "DRIVING";    //rootObject.main.humidity
        public string AddressPlaceId { get; set; } = null; //rootObject.clouds.all
        public string WorkAddressPlaceId { get; set; } = null;
        public double[] LatLng { get; set; }

        //convert to domain object
        public static explicit operator TrafficSettingsViewModel(Data.Models.TrafficSettings tsData)
        {
            TrafficSettingsViewModel trafficSettings = new TrafficSettingsViewModel()
            {
                Id = tsData.Fk_TrafficId,
                Enabled = tsData.Enabled,
                Address = tsData.Address,
                WorkAddress = tsData.WorkAddress,
                TravelMode = tsData.TravelMode,
                AddressPlaceId = tsData.AddressPlaceId,
                WorkAddressPlaceId = tsData.WorkAddressPlaceId,
                LatLng = tsData.LatLng
            };

            return trafficSettings;
        }

        //convert to entity object
        public static explicit operator Data.Models.TrafficSettings(TrafficSettingsViewModel ts)
        {
            Data.Models.TrafficSettings tsData = new Data.Models.TrafficSettings()
            {
                Fk_TrafficId = ts.Id,
                Enabled = ts.Enabled,
                Address = ts.Address,
                WorkAddress = ts.WorkAddress,
                TravelMode = ts.TravelMode,
                AddressPlaceId = ts.AddressPlaceId,
                WorkAddressPlaceId = ts.WorkAddressPlaceId,
                LatLng = ts.LatLng
            };

            return tsData;
        }
    }
}