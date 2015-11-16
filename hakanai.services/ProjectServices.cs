using Mehdime.Entity;
using hakanai.dal.Repositories;
using hakanai.domain.models;
using System;

namespace hakanai.services
{
    public class ProjectServices: IProjectServices

    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IProjectRepository _projectRepository;

        
            public ProjectServices(IDbContextScopeFactory dbContextScopeFactory, IProjectRepository projectRepository)
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

            if (string.IsNullOrWhiteSpace(project.Title))
            {
                return false;
            }
                

            using (var dbContextScope = _dbContextScopeFactory.Create())
            {

                //-- Persist
                _projectRepository.Add(project);
                return dbContextScope.SaveChanges() != 0 ? true : false;
            }
        }


        public bool RemoveProject(Project project)
        {

            using (var dbContextScope = _dbContextScopeFactory.Create())
            {

                //-- Persist
                _projectRepository.Remove(project);
                return dbContextScope.SaveChanges() != 0 ? true : false;
            }
        }

        public Project GetProject(Guid projectId)
        {
            var dbContextScope = _dbContextScopeFactory.Create();

            //-- Persist
            return _projectRepository.Get(projectId);
        }
    }
}
