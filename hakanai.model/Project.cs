using System;
using System.Collections.Generic;

namespace hakanai.domain.models
{
    public class Project
    {
        public Guid ProjectId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Photograph> Photographs { get; set; }

    }
}