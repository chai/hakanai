using hakanai.domain.models;
using System;

namespace hakanai.dal.Repositories
{
    public interface IProject
    {
        Project Get(Guid projectId);
        bool Add(Project project);

        bool Remove(Project project);
    }
}
