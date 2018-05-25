using System;
using Breakfast.Business.Weather.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Breakfast.Test
{
    [TestClass]
    public class TestModel
    {
        [TestMethod]
        public void TestWeatherDefaults()
        {
            //Arrange
            CurrentWeather cw = new CurrentWeather();

            //Act
            string expectedParam1 = "09d";
            char expectedParam2 = 'F';

            //Assert
            Assert.AreEqual(expectedParam1, cw.condition);
            Assert.AreEqual(expectedParam2, cw.temperatureType);
        }
    }
}
