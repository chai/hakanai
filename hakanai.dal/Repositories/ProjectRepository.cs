using hakanai.domain.models;
using Mehdime.Entity;
using System;
using System.Data.Entity;

namespace hakanai.dal.Repositories
{
    public class ProjectRepository : IProjectRepository
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
            bool currentValidation = DbContext.Configuration.ValidateOnSaveEnabled;
            try
            {
                DbContext.Configuration.ValidateOnSaveEnabled = false;
                DbContext.Projects.Attach(project);
                DbContext.Entry(project).State = EntityState.Deleted;
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
        }
    }
}
