using Microsoft.VisualStudio.TestTools.UnitTesting;
using Breakfast.Areas.Weather.Models;

namespace Breakfast.Web.Tests.Models
{
    [TestClass]
    public class OpenWeatherMapTest
    {
        [TestMethod]
        public void TestForecastSize()
        {
            //Arrange
            OpenWeatherMap owm = new OpenWeatherMap();

            //Act
            int expectedSize = 5;

            //Assert
            Assert.AreEqual(owm.forecastDays.Length, expectedSize);
        }
    }
}
