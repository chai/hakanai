using Mehdime.Entity;
using hakanai.dal.Repositories;
using hakanai.domain.models;
using System;
using System.Collections.Generic;

namespace hakanai.services
{
    public class PhotographServices: IPhotographServices

    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IPhotographRepository _photographRepository;


        public PhotographServices(IDbContextScopeFactory dbContextScopeFactory, IPhotographRepository photographRepository)
        {
            if (dbContextScopeFactory == null) throw new ArgumentNullException("dbContextScopeFactory");
            if (photographRepository == null) throw new ArgumentNullException("photographRepository");
            _dbContextScopeFactory = dbContextScopeFactory;
            _photographRepository = photographRepository;
        }

        public bool UploadPhotography(Photograph photograph)
        {
            if (photograph == null)
                throw new ArgumentNullException("userToCreate");


          //  userToCreate.Validate();

            /*
			 * Typical usage of DbContextScope for a read-write business transaction. 
			 * It's as simple as it looks.
			 */


            if (string.IsNullOrWhiteSpace(photograph.Title) || string.IsNullOrWhiteSpace (photograph.Location))
            {
                
                return false;
            }




            using (var dbContextScope = _dbContextScopeFactory.Create())
            {

                //-- Persist
                if( _photographRepository.Add(photograph))
                    {
                        return dbContextScope.SaveChanges() != 0 ? true : false;
                    }
                    
                    else{ return false; }
            }
        }


        public bool RemovePhotography(Photograph photograph)
        {

            using (var dbContextScope = _dbContextScopeFactory.Create())
            {

                //-- Persist
                if (_photographRepository.Remove(photograph)) 
                {
                    return dbContextScope.SaveChanges() != 0 ? true : false;
                }
                else{ return false; }

            }
        }


        public Photograph GetPhotograph(Guid photographId)
        {
            var dbContextScope = _dbContextScopeFactory.Create();
           
                //-- Persist
                return _photographRepository.Get(photographId);

                
                
                
            

        }


        public List<Photograph> GetAllPhotographs()
        {
            var dbContextScope = _dbContextScopeFactory.Create();

            
            //-- Persist
            return _photographRepository.GetAll(); ;

        }

    }
}
