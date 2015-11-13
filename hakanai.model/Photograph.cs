using System;
using System.Collections.Generic;

namespace hakanai.domain.models
{
    public class Photograph
    {
        public Guid PhotographId { get; set; }
        public string Title { get; set; }
        
        public string Location { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }

}
