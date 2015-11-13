using Mehdime.Entity;
using hakanai.dal.Repositories;
using hakanai.domain.models;
using System;

namespace hakanai.services
{
    public class ProjectServices
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IProject _projectRepository;

        
            public ProjectServices(IDbContextScopeFactory dbContextScopeFactory, ProjectRepository projectRepository)
        {
            if (dbContextScopeFactory == null) throw new ArgumentNullException("dbContextScopeFactory");
            if (projectRepository == null) throw new ArgumentNullException("projectRepository");
            _dbContextScopeFactory = dbContextScopeFactory;
            _projectRepository = projectRepository;
        }

        public bool CreateProject(Project project)
        {
            if (project == null)
                throw new ArgumentNullException("createProject");

          //  userToCreate.Validate();

            /*
			 * Typical usage of DbContextScope for a read-write business transaction. 
			 * It's as simple as it looks.
			 */
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {

                //-- Persist
                _projectRepository.Add(project);
                return dbContextScope.SaveChanges() != 0 ? true : false;
            }
        }


        public bool RemovePhotography(Project project)
        {

            using (var dbContextScope = _dbContextScopeFactory.Create())
            {

                //-- Persist
              //  _projectRepository.Remove(photograph);
                return dbContextScope.SaveChanges() != 0 ? true : false;
            }
        }


    }
}
