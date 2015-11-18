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
using AutoMapper;
using hakanai.ViewModels;

namespace hakanai.Tests.Controllers
{
    [TestClass]
    public class PhotographControllerTest
    {

        
        private IPhotographServices _photographServices=null;
        
        
    [ClassInitialize]
    public void SetupMapper()
        {

                        Mapper.CreateMap<Photograph, PhotoViewModel>()
    .ForMember("Taken", dest => dest.Ignore())
    .ForMember("File", dest => dest.Ignore())
    .ForMember("UrlLocation", x => x.MapFrom(scr => scr.Location))
    .ForMember(dest => dest.Projects, opt => opt.MapFrom(src => src.Projects.Select(p => p.ProjectId).ToList()));

            Mapper.AssertConfigurationIsValid();
        }
        

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

            var projectList = new List<Project>();
            projectList.Add(
                 new Project {
                     ProjectId = Guid.NewGuid(),
                     Title = "Project Title",
                     Description = "Description tex"
                 }
                
                );

            projectList.Add(
              new Project
              {
                  ProjectId = Guid.NewGuid(),
                  Title = "Project Title 2",
                  Description = "Description tex2"
              }

             );


            Photograph photo1 = new Photograph
            {
                PhotographId = Guid.NewGuid(),
                Title = "Test title",
                Location = "Test location",
                Projects = projectList

            };
            Photograph photo2 = new Photograph
            {
                PhotographId = Guid.NewGuid(),
                Title = "Test title 2",
                Location = "Test location 2",
                Projects = projectList
            };


            photoListToReturn.Add(photo1);
            photoListToReturn.Add(photo2);




            _photographServices.GetAllPhotographs().Returns(photoListToReturn);






            var result = photoController.ListOfPhotos() as ViewResult;

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
