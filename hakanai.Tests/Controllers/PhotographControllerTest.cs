using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using hakanai;
using hakanai.Controllers;
using System.IO;
using Mehdime.Entity;
using hakanai.dal.Repositories;
using NSubstitute;

using hakanai.services;
using hakanai.domain.models;

namespace hakanai.Tests.Controllers
{
    [TestClass]
    public class PhotographControllerTest
    {

        
        private IPhotographServices _photographServices=null;
        
        


        #region InitialisationAndTearDown
        [TestInitialize]
        public void Setup()
        {
            _photographServices = Substitute.For<IPhotographServices>();
            
        }


        [TestCleanup]
        public void TearDown()
        {

        }

        #endregion


        [TestMethod]
        public void GetListOfAllPhotographs()
        {

            //Arrange
            PhotographController photoController = new PhotographController(_photographServices);


            var photoListToReturn = new List<Photograph>();

            Photograph photo1 = new Photograph
            {
                PhotographId = Guid.NewGuid(),
                Title = "Test title",
                Location = "Test location"
            };
            Photograph photo2 = new Photograph
            {
                PhotographId = Guid.NewGuid(),
                Title = "Test title 2",
                Location = "Test location 2"
            };

            photoListToReturn.Add(photo1);
            photoListToReturn.Add(photo2);




            _photographServices.GetAllPhotographs().Returns(photoListToReturn);






            var result = photoController.List() as ViewResult;

            var photographList = result.Model as List<Photograph>;

            


            
            Assert.IsNotNull(result);

            Assert.AreEqual(photographList, new[] { photo1, photo2 });
            

        }


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
