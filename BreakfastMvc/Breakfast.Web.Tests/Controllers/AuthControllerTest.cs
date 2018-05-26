using System;
using System.Web.Mvc;
using Breakfast.Controllers;
using Breakfast.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Breakfast.Web.Tests.Controllers
{
    [TestClass]
    public class AuthControllerTest
    {
        [TestMethod]
        public void TestAuth()
        {
            //Arrange
            AuthController controller = new AuthController(false,false);
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
