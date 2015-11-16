using hakanai.domain.models;
using System;

namespace hakanai.dal.Repositories
{
    public interface IProjectRepository
    {
        Project Get(Guid projectId);
        bool Add(Project project);

        bool Remove(Project project);
    }
}
