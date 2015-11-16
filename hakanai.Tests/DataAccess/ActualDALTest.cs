using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using hakanai.domain.models;
using hakanai.dal.Repositories;
using Mehdime.Entity;
using hakanai.services;
using System.Collections.Generic;

namespace hakanai.Tests
{
    [TestClass]
    public class Dal
    {

        Guid uploadID; 
        [TestMethod]
        public void CreateANewPhotograph()        
        {


            var dbContextScopeFactory = new DbContextScopeFactory();
            var ambientDbContextLocator = new AmbientDbContextLocator();
            var photographRepository = new PhotographRepository(ambientDbContextLocator);




            var photographService = new PhotographServices(dbContextScopeFactory, photographRepository);
            //var userQueryService = new UserQueryService(dbContextScopeFactory, userRepository);
            //var userEmailService = new UserEmailService(dbContextScopeFactory);
            //var userCreditScoreService = new UserCreditScoreService(dbContextScopeFactory);

                                  
                Photograph newPhoto = new Photograph();
                
                newPhoto.Location = "testlocation";




            
            


            Assert.IsTrue(photographService.UploadPhotography(newPhoto));


            uploadID = newPhoto.PhotographId;
            Assert.IsTrue(photographService.RemovePhotography(newPhoto));

        }



        [TestMethod]
        public void DeletePhotograph()
        {

            CreateANewPhotograph();


            var dbContextScopeFactory = new DbContextScopeFactory();
            var ambientDbContextLocator = new AmbientDbContextLocator();
            var photographRepository = new PhotographRepository(ambientDbContextLocator);




            var photographService = new PhotographServices(dbContextScopeFactory, photographRepository);
            //var userQueryService = new UserQueryService(dbContextScopeFactory, userRepository);
            //var userEmailService = new UserEmailService(dbContextScopeFactory);
            //var userCreditScoreService = new UserCreditScoreService(dbContextScopeFactory);







            Assert.IsTrue(photographService.RemovePhotography((new Photograph { PhotographId = uploadID })));





        }


        





                    
        [TestMethod]
        public void GetAPhotograph()
        {


            var dbContextScopeFactory = new DbContextScopeFactory();
            var ambientDbContextLocator = new AmbientDbContextLocator();
            var photographRepository = new PhotographRepository(ambientDbContextLocator);




            var photographService = new PhotographServices(dbContextScopeFactory, photographRepository);
            //var userQueryService = new UserQueryService(dbContextScopeFactory, userRepository);
            //var userEmailService = new UserEmailService(dbContextScopeFactory);
            //var userCreditScoreService = new UserCreditScoreService(dbContextScopeFactory);






            var photo = photographService.GetPhotograph(new Guid("9a1f9e3e-b389-e511-9c5a-00249b0905d8"));
           foreach (var photographInProject in photo.Projects)
            {
                foreach (var actualPhoto in photographInProject.Photographs)
                {

                    string a= actualPhoto.Title;
                }

            }

            
            var photo2 = photographService.GetPhotograph(new Guid("1a1f9e3e-b389-e511-9c5a-00249b0905d8"));
            Assert.IsNotNull(photo);

        }




        [TestMethod]
        public void GetAllPhotograph()
        {


            var dbContextScopeFactory = new DbContextScopeFactory();
            var ambientDbContextLocator = new AmbientDbContextLocator();
            var photographRepository = new PhotographRepository(ambientDbContextLocator);




            var photographService = new PhotographServices(dbContextScopeFactory, photographRepository);


            var photo = photographService.GetAllPhotographs();
            //foreach (var photograph in photo)
            //{
            //    var tempt = photograph.Title;

            //    foreach(var tempphot in photograph.Projects)
            //    {
            //        var t = tempphot.Title;
                    
            //    }

            //}
            Assert.IsNotNull(photo);
            

        }



        [TestMethod]
        public void CreateNewProjectWithPhotograph()
        {


            var dbContextScopeFactory = new DbContextScopeFactory();
            var ambientDbContextLocator = new AmbientDbContextLocator();
            var projectRepository = new ProjectRepository(ambientDbContextLocator);



            var photographs = new List<Photograph>();
            photographs.Add(new Photograph {

                Location="home",
                Title="photo title"

            });


            photographs.Add(new Photograph
            {

                Location = "home2",
                Title = "photo title2"

            });


            var projectService = new ProjectServices(dbContextScopeFactory, projectRepository);

            Project project = new Project
            {
                Description = "test",
                Title = "Test title",
                Photographs = photographs
            };


            projectService.CreateProject(project);
        }
    }
}
