using Microsoft.VisualStudio.TestTools.UnitTesting;
using hakanai.domain.models;
using hakanai.dal.Repositories;
using Mehdime.Entity;
using hakanai.services;
using NSubstitute;
using System;

namespace hakanai.Tests
{
    [TestClass]
    public class PhotographyServiceTest
    {
        private IDbContextScopeFactory _dbContextScopeFactory = null;
        private IAmbientDbContextLocator _ambientDbContextLocator = null;
        private IPhotographRepository _photographRepository = null;
        private IDbContextScope _dbContext = null;
        private PhotographServices _photographService = null;

        [TestInitialize]
        public void Setup()
        {
            _dbContextScopeFactory = Substitute.For<IDbContextScopeFactory>();
            _ambientDbContextLocator = Substitute.For<IAmbientDbContextLocator>();
            _photographRepository = Substitute.For<IPhotographRepository>();
            _dbContext = Substitute.For<IDbContextScope>();
            _dbContextScopeFactory.Create().Returns(_dbContext);
            _photographService = new PhotographServices(_dbContextScopeFactory, _photographRepository);
        }


        [TestCleanup]
        public void TearDown()
        {

        }

        #region Upload


        [TestMethod]
        public void CreateANewPhotograph()        
        {

            //Arrange

            _dbContext.SaveChanges().Returns(1);
            Photograph newPhoto = new Photograph();
            newPhoto.Title = "test";
            newPhoto.Location = "testlocation";
            _photographRepository.Add(newPhoto).Returns(true);
            //Act


            bool result = _photographService.UploadPhotography(newPhoto);

            //Assert

            Assert.IsTrue(result);            
        }


        [TestMethod]
        public void CreateANewPhotographFailToAddToDb()
        {

            //Arrange

            _dbContext.SaveChanges().Returns(0);
            Photograph newPhoto = new Photograph();
            newPhoto.Title = "test";
            newPhoto.Location = "testlocation";
            _photographRepository.Add(newPhoto).Returns(false);
            //Act


            bool result = _photographService.UploadPhotography(newPhoto);

            //Assert

            Assert.IsFalse(result);
        }



        [TestMethod]
        public void CreateANewPhotographFailToSave()
        {

            //Arrange

            _dbContext.SaveChanges().Returns(0);
            Photograph newPhoto = new Photograph();
            newPhoto.Title = "test";
            newPhoto.Location = "testlocation";
            _photographRepository.Add(newPhoto).Returns(true);
            //Act


            bool result = _photographService.UploadPhotography(newPhoto);

            //Assert

            Assert.IsFalse(result);
        }

        
        //[ExpectedException(typeof(DbEntityValidationException))]
        

        [TestMethod]       
        public void CreateAPhotographWithoutTitle()
        {

            //Arrange

            _dbContext.SaveChanges().Returns(1);
            Photograph newPhoto = new Photograph();
            newPhoto.Location = "testlocation";
            _photographRepository.Add(newPhoto).Returns(true);
            //Act


            bool result = _photographService.UploadPhotography(newPhoto);

            //Assert

            Assert.IsFalse(result);

        }


        [TestMethod]
        public void CreateAPhotographWithoutLocation()
        {

            //Arrange

            _dbContext.SaveChanges().Returns(1);
            Photograph newPhoto = new Photograph();
            newPhoto.Title = "testlocation";
            _photographRepository.Add(newPhoto).Returns(true);
            //Act


            bool result = _photographService.UploadPhotography(newPhoto);

            //Assert

            Assert.IsFalse(result);

        }



        [TestMethod]
        public void CreateAPhotographWithoutLocationAndTitle()
        {

            //Arrange

            _dbContext.SaveChanges().Returns(1);
            Photograph newPhoto = new Photograph();            
            _photographRepository.Add(newPhoto).Returns(true);
            //Act


            bool result = _photographService.UploadPhotography(newPhoto);

            //Assert

            Assert.IsFalse(result);

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAPhotographWitNullPhotograph()
        {

            //Arrange

            _dbContext.SaveChanges().Returns(x => { throw new ArgumentNullException(); });
            Photograph newPhoto = null;
            
            _photographRepository.Add(newPhoto).Returns(true);
            //Act

            bool result = _photographService.UploadPhotography(newPhoto);

            //Assert

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAPhotographWitNullRepository()
        {

           //Act
            _photographService = new PhotographServices(_dbContextScopeFactory, null);
            
            //Assert

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAPhotographWitNullContextScope()
        {

            //Act
            _photographService = new PhotographServices(null, _photographRepository);

            //Assert

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAPhotographWitNullContextScopeAndNullRepository()
        {

            //Act
            _photographService = new PhotographServices(null, null);

            //Assert

        }


        #endregion




        #region GetPhotograph
        [TestMethod]
        public void GetExistingPhotograph()
        {

            //Arrange            
            Photograph newPhoto = new Photograph();
            
            newPhoto.PhotographId
            _photographRepository.Add(newPhoto).Returns(true);
            //Act


            bool result = _photographService.UploadPhotography(newPhoto);

            //Assert

            Assert.IsTrue(result);
        }


        #endregion





    }
}
