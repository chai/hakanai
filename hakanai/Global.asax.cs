using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using hakanai.domain.models;
using hakanai.ViewModels;


namespace hakanai
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            Mapper.CreateMap<Photograph, PhotoViewModel>()
                .ForMember("Taken", dest => dest.Ignore())
                .ForMember("File", dest => dest.Ignore())
                .ForMember("UrlLocation", x => x.MapFrom(scr => scr.Location))
                .ForMember(dest => dest.Projects, opt => opt.MapFrom(src => src.Projects.Select(p => p.ProjectId).ToList()));


                //.ForMember(dest => dest.Tags, opt => opt.MapFrom(so => so.Tags.Select(t=>t.Name).ToList()));


            //Mapper.CreateMap <Project, >
            Mapper.AssertConfigurationIsValid();

            


        }
    }
}
