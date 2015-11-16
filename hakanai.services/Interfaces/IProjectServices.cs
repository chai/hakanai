using hakanai.domain.models;
using System;

namespace hakanai.services
{
    public interface IProjectServices
    {
        bool CreateProject(Project project);
        bool RemoveProject(Project project);
        Project GetProject(Guid projectId);
    }
}