using hakanai.domain.models;
using System;

namespace hakanai.services
{
    public interface IPhotographServices
    {
 
        bool UploadPhotography(Photograph photograph);
        bool RemovePhotography(Photograph photograph);
        Photograph GetPhotograph(Guid photographId);
    }
}