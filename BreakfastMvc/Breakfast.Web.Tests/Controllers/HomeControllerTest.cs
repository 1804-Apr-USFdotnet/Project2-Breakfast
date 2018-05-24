using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Breakfast;
using Breakfast.Controllers;

namespace Breakfast.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestHome()
        {
            //Arrange
            HomeController controller = new HomeController();
            bool expectedReadOnly = false;
            bool expectedValid = true;

            //Act
            bool isReadOnly = controller.ModelState.IsReadOnly;
            bool isValid = controller.ModelState.IsValid;

            //Assert
            Assert.AreEqual(expectedReadOnly, isReadOnly);
            Assert.AreEqual(expectedValid, isValid);
        }
    }
}
