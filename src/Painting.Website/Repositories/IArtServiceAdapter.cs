using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Painting.Website.Repositories
{
    public interface IArtServiceAdapter
    {
        Task<IEnumerable<Painting.Website.ViewModel.PaintingViewModel>> GetDataPaintingsAsync(IEnumerable<string> numbers, string key); 
    }
}



