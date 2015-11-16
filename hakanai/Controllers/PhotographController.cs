using System;
using System.Web.Mvc;
using hakanai.services;
namespace hakanai.Controllers
{
    public class PhotographController
    {

        private IPhotographServices _photographService;


        public PhotographController(IPhotographServices photographService)
        {
            _photographService = photographService;
        }

        public ViewResult Upload()
        {

            return new ViewResult();
        }

        public ViewResult List()
        {

            var temp = _photographService.GetAllPhotographs();
            return new ViewResult();
        }
    }
}