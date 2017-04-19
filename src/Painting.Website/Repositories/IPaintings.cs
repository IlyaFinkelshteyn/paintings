using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Painting.Website.Repositories
{
    public interface IPaintings
    {
        Task<IEnumerable<string>> GetObjectNumberAsync(string key);
    }
}
