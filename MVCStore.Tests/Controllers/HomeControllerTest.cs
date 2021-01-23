using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCStore;
using MVCStore.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MVCStore.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void List()
        {
            // Arrange
            ProductController controller = new ProductController();

            // Act
           // ViewResult result = controller.List() as ViewResult;

            // Assert
          //  Assert.IsNotNull(result);
        }
    }
}
