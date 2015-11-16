using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using hakanai;
using hakanai.Controllers;
using System.IO;

namespace hakanai.Tests.Controllers
{
    [TestClass]
    public class PhotographControllerTest
    {
        [TestMethod]
        public void UploadFileGoesToResult()
        {
            // Arrange
            PhotographController controller = new PhotographController(null);        
            // Act
            ViewResult result = controller.Upload() as ViewResult;
                        
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UploadedFileSavedToServer()
        {
            //Arrange
            PhotographController controller = new PhotographController(null);
            

            //Act
            ViewResult result = controller.Upload() as ViewResult;

            //Assert
            string filePathResult = null;

            string actualFile = Path.GetFileName(filePathResult);
            Assert.IsNotNull(actualFile);
            Assert.AreNotEqual(String.Empty, actualFile);
            Assert.IsNotNull(result);

        }
    }
}
