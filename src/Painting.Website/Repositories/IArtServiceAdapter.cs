using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Painting.Website.Repositories
{
    public interface IArtServiceAdapter
    {
        Task<string> ReadApiAsync(string key);
    }
}



