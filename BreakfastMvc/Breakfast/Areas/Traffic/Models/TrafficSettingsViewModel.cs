﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Breakfast.ViewModels;
using Newtonsoft.Json;

namespace Breakfast.Areas.Traffic.Models
{

    public class TrafficSettingsViewModel
    {
        //        const string path = @"http://ec2-18-191-47-17.us-east-2.compute.amazonaws.com/Breakfast.Service_deploy/api/traffic/get/";
        const string path = @"http://localhost:50105/api/traffic/get/";

        public int Id { get; set; }
        public bool Enabled { get; set; } = true;
        public string Address { get; set; } = null;
        public string WorkAddress { get; set; } = null;  
        public bool Driving { get; set; } = true;    
        public string AddressPlaceId { get; set; } = null; 
        public string WorkAddressPlaceId { get; set; } = null;
        public double[] LatLng { get; set; }
        public string UserId { get; set; }
        public string TimeToWork { get; set; }

        public static async Task<string> SetTimeToWork(TrafficSettingsViewModel tsvm)
        {
            HttpClient client = new HttpClient();
            string travelMode = (tsvm.Driving) ? "DRIVING" : "WALKING";
            string url = path + tsvm.AddressPlaceId + "/" + tsvm.WorkAddressPlaceId + "/" + travelMode;
            var response = await client.GetAsync(url);
            string result = null;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            TimeJsonResponse timeJson = JsonConvert.DeserializeObject<TimeJsonResponse>(result);
            return timeJson.Time;



        }
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