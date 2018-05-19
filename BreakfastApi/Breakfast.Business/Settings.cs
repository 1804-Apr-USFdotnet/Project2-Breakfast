﻿using Breakfast.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakfast.Business
{
    static public class Settings
    {
        static public string getSettings(string userId)
        {
            Storage storage = new Storage(new DefaultDBUtils());
            return JsonConvert.SerializeObject(storage.GetSettings(userId));
        }

        static public void initializeSettings(string userId)
        {
            Storage storage = new Storage(new DefaultDBUtils());
            storage.InitializeSettings(new Data.Models.SettingsTable()
            {
                Fk_Email = userId,

                //
                //   Default news settings on account creation
                //
                News = new Data.Models.NewsSettings()
                {
                    Enabled = true,
                    //TODO: Add default news settings
                },

                //
                //   Default traffic settings on account creation
                //
                Traffic = new Data.Models.TrafficSettings()
                {
                    Enabled = true,
                    //TODO: Add default traffic settings
                },

                //
                //   Default weather settings on account creation
                //
                Weather = new Data.Models.WeatherSettings()
                {
                    Enabled = true,
                    Cloudiness = false,
                    Farenheit = true,
                    Humidity = true,
                    Location = "33617",
                    WindSpeed = false
                }
            });
        }
    }
}