using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace painting.models.repositories
{
    interface IArtServiceAdapter
    {
        Task<IEnumerable<string>> GetObjectNumberAsync(string key);
        Task<string[]> GetDataPaintingsAsync(IEnumerable<string> numbers, string key);
    }
}



