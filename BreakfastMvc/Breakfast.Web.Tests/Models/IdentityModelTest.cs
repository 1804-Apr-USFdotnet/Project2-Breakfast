using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Breakfast.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Breakfast.Web.Tests.Models
{
    [TestClass]
    public class IdentityModelTest
    {
        [TestMethod]
        public void AppUserTest()
        {
            //Arrange
            AppUser user = new AppUser();

            //Act
            string expectedParam1 = "address";
            string expectedParam2 = "workAddress";
            string expectedParam3 = "zipcode";

            //Assert
            Assert.AreEqual(expectedParam1, nameof(user.address));
            Assert.AreEqual(expectedParam2, nameof(user.workAddress));
            Assert.AreEqual(expectedParam3, nameof(user.zipcode));
        }
    }
}
