using Microsoft.VisualStudio.TestTools.UnitTesting;
using hakanai.domain.models;
using hakanai.dal.Repositories;
using Mehdime.Entity;
using hakanai.services;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace hakanai.Tests
{
    [TestClass]
    public class ProjectServiceTest
    {
        private IDbContextScopeFactory _dbContextScopeFactory = null;
        private IAmbientDbContextLocator _ambientDbContextLocator = null;
        private IProjectRepository _projectRepository = null;
        private IDbContextScope _dbContext = null;
        private ProjectServices _projectService = null;
        #region InitialiseAndTearDown

        [TestInitialize]
        public void Setup()
        {
            _dbContextScopeFactory = Substitute.For<IDbContextScopeFactory>();
            _ambientDbContextLocator = Substitute.For<IAmbientDbContextLocator>();
            _projectRepository = Substitute.For<IProjectRepository>();
            _dbContext = Substitute.For<IDbContextScope>();
            _dbContextScopeFactory.Create().Returns(_dbContext);
            _projectService = new ProjectServices(_dbContextScopeFactory, _projectRepository);
        }


        [TestCleanup]
        public void TearDown()
        {

        }
        #endregion

        #region Upload


        [TestMethod]
        public void CreateANewProject()        
        {

            //Arrange

            _dbContext.SaveChanges().Returns(1);


            Project creatProject = new Project();

            creatProject.Title = "test";
            creatProject.Description = "test description";


            Photograph newPhoto = new Photograph();
            newPhoto.PhotographId = Guid.NewGuid();
            newPhoto.Title = "Test Title";
            newPhoto.Location = "location of photo";


            Photograph newPhoto2 = new Photograph();
            newPhoto.PhotographId = Guid.NewGuid();
            newPhoto.Title = "Test Title2";
            newPhoto.Location = "location of photo2";

            var photographs = new List<Photograph>();

            photographs.Add(newPhoto);
            photographs.Add(newPhoto2);

            creatProject.Photographs = photographs;
            

            _projectRepository.Add(creatProject).Returns(true);
            //Act


            bool result = _projectService.CreateProject(creatProject);

            //Assert

            Assert.IsTrue(result);            
        }


        [TestMethod]
        public void CreateANewProjectFailToAddToDb()
        {

            //Arrange

            _dbContext.SaveChanges().Returns(0);


            Project creatProject = new Project();

            creatProject.Title = "test";
            creatProject.Description = "test description";

            Photograph newPhoto = new Photograph();
            newPhoto.PhotographId = Guid.NewGuid();
            newPhoto.Title = "Test Title";
            newPhoto.Location = "location of photo";


            var photographs = new List<Photograph>();

            photographs.Add(newPhoto);
            

            creatProject.Photographs = photographs;


            _projectRepository.Add(creatProject).Returns(false);
            //Act


            bool result = _projectService.CreateProject(creatProject);

            //Assert

            Assert.IsFalse(result);
        }



        [TestMethod]
        public void CreateANewProjectFailToSave()
        {

            //Arrange

            _dbContext.SaveChanges().Returns(0);

            Project creatProject = new Project();

            creatProject.Title = "test";
            creatProject.Description = "test description";

            Photograph newPhoto = new Photograph();
            newPhoto.PhotographId = Guid.NewGuid();
            newPhoto.Title = "Test Title";
            newPhoto.Location = "location of photo";


            var photographs = new List<Photograph>();

            photographs.Add(newPhoto);
            

            creatProject.Photographs = photographs;



            _projectRepository.Add(creatProject).Returns(true);

            
            //Act


            bool result = _projectService.CreateProject(creatProject);

            //Assert

            Assert.IsFalse(result);
        }

        
        //[ExpectedException(typeof(DbEntityValidationException))]
        

        [TestMethod]       
        public void CreateAProjectWithoutTitle()
        {

            //Arrange

            _dbContext.SaveChanges().Returns(1);

            Project creatProject = new Project();
            
            creatProject.Description = "test description";

            Photograph newPhoto = new Photograph();
            newPhoto.PhotographId = Guid.NewGuid();
            newPhoto.Title = "Test Title";
            newPhoto.Location = "location of photo";



            var photographs = new List<Photograph>();

            photographs.Add(newPhoto);
            

            creatProject.Photographs = photographs;



            _projectRepository.Add(creatProject).Returns(true);
            //Act


            bool result = _projectService.CreateProject(creatProject);

            //Assert

            Assert.IsFalse(result);

        }


        [TestMethod]
        public void CreateAProjectWithoutDescription()
        {

            //Arrange

            Project creatProject = new Project();

            creatProject.Title = "test";
            Photograph newPhoto = new Photograph();
            newPhoto.PhotographId = Guid.NewGuid();
            newPhoto.Title = "Test Title";
            newPhoto.Location = "location of photo";


            var photographs = new List<Photograph>();

            photographs.Add(newPhoto);
            

            creatProject.Photographs = photographs;




            _projectRepository.Add(creatProject).Returns(true);
            //Act


            bool result = _projectService.CreateProject(creatProject);

            //Assert

            Assert.IsFalse(result);

        }



        [TestMethod]
        public void CreateAProjectWithoutDescriptionTitleAndPhoto()
        {

            //Arrange

            _dbContext.SaveChanges().Returns(1);


            Project creatProject = new Project();




            _projectRepository.Add(creatProject).Returns(false);
            //Act


            bool result = _projectService.CreateProject(creatProject);

            //Assert

            Assert.IsFalse(result);

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAProjectWitNullProject()
        {

            //Arrange

            _dbContext.SaveChanges().Returns(x => { throw new ArgumentNullException(); });
            Project newProject = null;
            
            _projectRepository.Add(newProject).Returns(true);
            //Act

            bool result = _projectService.CreateProject(newProject);

            //Assert

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAProjectWithNullRepository()
        {

            //Act
            _projectService = new ProjectServices(_dbContextScopeFactory, (IProjectRepository)null);
            
            //Assert

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAProjectWithNullContextScope()
        {

            //Act
            _projectService = new ProjectServices(null, _projectRepository);

            //Assert

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAProjectWitNullContextScopeAndNullRepository()
        {

            //Act
            _projectService = new ProjectServices(null, (IProjectRepository)null);

            //Assert

        }


        #endregion




        #region GetPhotograph
        [TestMethod]
        public void GetExistingProject()
        {

            //Arrange            
            Project existingProject = new Project();
            existingProject.Description = "project descriptiopn";
            existingProject.Title = "Project title";
            existingProject.ProjectId = Guid.NewGuid();
            

            _projectRepository.Get(existingProject.ProjectId).Returns(existingProject);


            //Act


            Project projectFromDB = _projectService.GetProject(existingProject.ProjectId);

            //Assert
            Assert.AreEqual(existingProject.ProjectId, projectFromDB.ProjectId);
            Assert.AreEqual(existingProject.Title, projectFromDB.Title);
            Assert.AreEqual(existingProject.Description, projectFromDB.Description);

        }


        #endregion





    }
}
