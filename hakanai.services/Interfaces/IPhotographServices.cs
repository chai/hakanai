using hakanai.domain.models;
using System;
using System.Collections.Generic;

namespace hakanai.services
{
    public interface IPhotographServices
    {
 
        bool UploadPhotography(Photograph photograph);
        bool RemovePhotography(Photograph photograph);
        Photograph GetPhotograph(Guid photographId);
        List<Photograph> GetAllPhotographs();
    }
}