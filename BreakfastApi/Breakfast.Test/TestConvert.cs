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
    }
}
