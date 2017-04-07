using System.Collections;


namespace painting.models.repositories
{
    interface objectNumberInterface
    {
        System.Threading.Tasks.Task<IEnumerable> GetObjectNumberAsync();
        System.Threading.Tasks.Task<IEnumerable> GetDataPaintingsAsync(System.Collections.IEnumerable objectnumbers);
    }
}



