using Breakfast.Data;
using System.Collections.Generic;

namespace Breakfast.Business
{
    static public class Settings
    {
        static public SettingsModel getSettings(string userId)
        {
            Storage storage = new Storage(new DefaultDBUtils());
            return (SettingsModel)storage.GetSettings(userId);
        }

        static public void initializeSettings(string userId)
        {
            Storage storage = new Storage(new DefaultDBUtils());
            storage.InitializeSettings(new Data.Models.SettingsTable()
            {
                Pk_Email = userId,

                //
                //   Default news settings on account creation
                //
            NewsSettings = new Data.Models.NewsSettings()
            {
                Enabled = true,
                Queries = "Bitcoin",
                Domains = null,
                Sources = null,
                OldestDate = null,
                NewestDate = null,
                Language = null,
                PageSize = null
                //TODO: Add default news settings
            },

                //
                //   Default traffic settings on account creation
                //
                TrafficSettings = new Data.Models.TrafficSettings()
                {
                    Enabled = true,
                    Address = "",
                    WorkAddress = "",
                    Driving = true,
                    AddressPlaceId = "",
                    WorkAddressPlaceId = "",
                    LatLng = null
                },

                //
                //   Default weather settings on account creation
                //
                WeatherSettings = new Data.Models.WeatherSettings()
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

        static public void initializeSettings(string userId, string homeAddress, string workAddress)
        {
            Storage storage = new Storage(new DefaultDBUtils());
            storage.InitializeSettings(new Data.Models.SettingsTable()
            {
                Pk_Email = userId,

                //
                //   Default news settings on account creation
                //
                NewsSettings = new Data.Models.NewsSettings()
                {
                    Enabled = true,
                    Queries = "Bitcoin",
                    Domains = null,
                    Sources = null,
                    OldestDate = null,
                    NewestDate = null,
                    Language = null,
                    PageSize = null
                    //TODO: Add default news settings
                },

                //
                //   Default traffic settings on account creation
                //
                TrafficSettings = new Data.Models.TrafficSettings()
                {
                    Enabled = true,
                    Address = homeAddress,
                    WorkAddress = workAddress,
                    Driving = true,
                    AddressPlaceId = "",
                    WorkAddressPlaceId = "",
                    LatLng = null
                },

                //
                //   Default weather settings on account creation
                //
                WeatherSettings = new Data.Models.WeatherSettings()
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
