using hakanai.domain.models;
using System;
using Mehdime.Entity;
using System.Data.Entity;

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
