using hakanai.domain.models;
using System;

namespace hakanai.dal.Repositories
{
    public interface IPhotographRepository
    {
        Photograph Get(Guid photographId);
        bool Add(Photograph photograph);

        bool Remove(Photograph photograh);
    }
}
