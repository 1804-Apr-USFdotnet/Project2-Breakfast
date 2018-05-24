using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakfast.Business.Traffic.Models
{
    public class TrafficSettingsBusiness
    {
        public int Id { get; set; }
        public bool Enabled { get; set; } = true;
        public string Address { get; set; } = null;
        public string WorkAddress { get; set; } = null;
        public bool Driving { get; set; } = true;
        public string AddressPlaceId { get; set; } = null;
        public string WorkAddressPlaceId { get; set; } = null;
        public double[] LatLng { get; set; }

        //convert to domain object
        public static explicit operator TrafficSettingsBusiness(Data.Models.TrafficSettings tsData)
        {
            TrafficSettingsBusiness tsb = new TrafficSettingsBusiness()
            {
                Id = tsData.Pk_TrafficId,
                Enabled = tsData.Enabled,
                Address = tsData.Address,
                WorkAddress = tsData.WorkAddress,
                Driving = tsData.Driving,
                AddressPlaceId = tsData.AddressPlaceId,
                WorkAddressPlaceId = tsData.WorkAddressPlaceId,
                LatLng = tsData.LatLng
            };

            return tsb;
        }

        //convert to entity object
        public static explicit operator Data.Models.TrafficSettings(TrafficSettingsBusiness tsb)
        {
            Data.Models.TrafficSettings tsData = new Data.Models.TrafficSettings()
            {
                Pk_TrafficId = tsb.Id,
                Enabled = tsb.Enabled,
                Address = tsb.Address,
                WorkAddress = tsb.WorkAddress,
                Driving = tsb.Driving,
                AddressPlaceId = tsb.AddressPlaceId,
                WorkAddressPlaceId = tsb.WorkAddressPlaceId,
                LatLng = tsb.LatLng
            };

            return tsData;
        }
    }
}
