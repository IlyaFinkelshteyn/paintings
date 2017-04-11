using System.Collections;


namespace painting.models.repositories
{
    interface IArtServiceAdapter
    {
        System.Threading.Tasks.Task<IEnumerable> GetObjectNumberAsync();
        
    }
}



