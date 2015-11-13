using hakanai.domain.models;
using Mehdime.Entity;
using System;

namespace hakanai.dal.Repositories
{
    public class ProjectRepository : IProject
    {

        private readonly IAmbientDbContextLocator _ambientDbContextLocator;

        private HakanaiDBContext DbContext
        {
            get
            {
                return DatabaseDBContextFactory.Create(_ambientDbContextLocator);
            }
        }

        public ProjectRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            if (ambientDbContextLocator == null) throw new ArgumentNullException("ambientDbContextLocator");
            _ambientDbContextLocator = ambientDbContextLocator;
        }


        public Project Get(Guid projectId)
        {

            return null;
        }
        public bool Add(Project project)
        {
            return DbContext.Projects.Add(project) != null ? true : false;
        }

        public bool Remove(Project project)
        {
            return false;
        }
    }
}
