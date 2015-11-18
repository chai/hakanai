using System;
using System.Web.Mvc;
using hakanai.services;
using AutoMapper;
using hakanai.ViewModels;
using System.Collections.Generic;
using hakanai.domain.models;

namespace hakanai.Controllers
{
    public class PhotographController: Controller
    {

        private IPhotographServices _photographService;


        

        public PhotographController(IPhotographServices photographService)
        {
            _photographService = photographService;
        }

        public ActionResult Upload()
        {

            return new ViewResult();
        }

        public ActionResult ListOfPhotos()
        {

            var temp = _photographService.GetAllPhotographs();

            // Perform mapping
            List<PhotoViewModel> listOfAllPhotograph = Mapper.Map<List<Photograph> , List<PhotoViewModel>>(temp);



            return View(listOfAllPhotograph);
        }
    }
}