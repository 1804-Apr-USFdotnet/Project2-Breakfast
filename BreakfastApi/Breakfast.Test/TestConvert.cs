using System;
using Breakfast.Business.Weather.Models;
using Breakfast.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Breakfast.Test
{
    [TestClass]
    public class TestConvert
    {
        [TestMethod]
        public void WeatherBusinessToData()
        {
            //Arrange
            WeatherSettings ws = new WeatherSettings
            {
                enabled = false,
                humidity = true,
                cloudiness = true,
                windSpeed = false
            };

            //Act
            Data.Models.WeatherSettings wsData = (Data.Models.WeatherSettings)ws;
            bool param1 = false;
            bool param2 = true;
            bool param3 = true;
            bool param4 = false;

            //Assert
            Assert.AreEqual(wsData.Enabled, param1);
            Assert.AreEqual(wsData.Humidity, param2);
            Assert.AreEqual(wsData.Cloudiness, param3);
            Assert.AreEqual(wsData.WindSpeed, param4);
        }

        [TestMethod]
        public void WeatherDataToBusiness()
        {
            //Arrange
            Data.Models.WeatherSettings wsData = new Data.Models.WeatherSettings()
            {
                Enabled = false,
                Humidity = true,
                Cloudiness = true,
                WindSpeed = false
            };

            //Act
            WeatherSettings ws = (WeatherSettings)wsData;
            bool param1 = false;
            bool param2 = true;
            bool param3 = true;
            bool param4 = false;

            //Assert
            Assert.AreEqual(ws.enabled, param1);
            Assert.AreEqual(ws.humidity, param2);
            Assert.AreEqual(ws.cloudiness, param3);
            Assert.AreEqual(ws.windSpeed, param4);
        }
    }
}
