using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebDemo;
using WebDemo.Controllers;
using System.Threading.Tasks;

namespace WebDemo.Tests.Controllers
{
    [TestClass]
    public class ChainControllerTest
    {
        [TestMethod]
        public async Task Index()
        {
            // Arrange
            ChainController controller = new ChainController();

            // Act
            ViewResult result = await controller.Details("gbst1") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
