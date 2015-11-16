using hakanai.domain.models;
using System;
using Mehdime.Entity;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace hakanai.dal.Repositories
{
    public class PhotographRepository: IPhotographRepository
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;

        private HakanaiDBContext DbContext
        {
            get
            {            
                return DatabaseDBContextFactory.Create(_ambientDbContextLocator);
            }
        }

        public PhotographRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            if (ambientDbContextLocator == null) throw new ArgumentNullException("ambientDbContextLocator");
            _ambientDbContextLocator = ambientDbContextLocator;
        }



        public Photograph Get(Guid photographId)
        {

            return DbContext.Photographs.Find(photographId);
            
        }

        public List <Photograph> GetAll()
        {

            //List<Photograph> listOfAllPhotograph = await DbContext.Photographs.ToListAsync();

            //var temp2= DbContext.Set<Photograph>().Select(s => new { PhotographId = s.PhotographId, Location = s.Location, Projects = s.Projects, Title = s.Title }).ToList();

            //List<Photograph> returnList = new List<Photograph>();

            //foreach (var item in temp2)
            //{
            //    returnList.Add (

            //        new Photograph
            //        {
            //            PhotographId = item.PhotographId,
            //            Location = item.Location,
            //            Projects = item.Projects,
            //            Title = item.Title
            //        }
            //    );
            //}



            //var itemList = from photograph in DbContext.Photographs
            //               where photograph.Location.Length > 0
            //               select photograph;

            //Projection on to Anonymous object, can't return it as it only existing in this method
            // Projection onto Linq and use that to project on to a list
            //http://stackoverflow.com/questions/5325797/the-entity-cannot-be-constructed-in-a-linq-to-entities-query


            return DbContext.Set<Photograph>().Select(s => new { PhotographId = s.PhotographId, Location = s.Location, Projects = s.Projects, Title = s.Title })
                .ToList()
                .Select(s => new Photograph { PhotographId = s.PhotographId, Location = s.Location, Projects = s.Projects, Title = s.Title })
                .ToList<Photograph>();

                

            
        }

        public bool Add(Photograph photograph)
        {


            return DbContext.Photographs.Add(photograph) != null ? true : false;
            //DbContext.Photographs.Add(photograph);
            //return DbContext.SaveChanges() == 1 ? true : false;

        }

        public bool Remove(Photograph photograph)
        {
            bool currentValidation = DbContext.Configuration.ValidateOnSaveEnabled;
            try {
                DbContext.Configuration.ValidateOnSaveEnabled = false;
                DbContext.Photographs.Attach(photograph);
                DbContext.Entry(photograph).State = EntityState.Deleted;
                return true;
            }
            catch
            {

                return false;
            }
            finally
            {
                DbContext.Configuration.ValidateOnSaveEnabled = currentValidation;
            }
            //return DbContext.Photographs.Remove(photograph) != null ? true : false;

        }

        
    }
}
