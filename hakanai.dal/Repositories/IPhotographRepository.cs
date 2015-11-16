using hakanai.domain.models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace hakanai.dal.Repositories
{
    public interface IPhotographRepository
    {
        Photograph Get(Guid photographId);
        bool Add(Photograph photograph);

        bool Remove(Photograph photograh);
        List<Photograph> GetAll();
    }
}
