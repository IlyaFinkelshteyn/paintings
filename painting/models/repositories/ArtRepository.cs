using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using static painting.models.Rijksmuseum;
using System.Threading.Tasks;

namespace painting.models.repositories
{
    public class ObjectNumberRepository : IArtServiceAdapter
    {
        public ObjectNumberRepository(HttpClient mockedHttpClient)
        {
            Client = mockedHttpClient; 
        }

        private HttpClient Client { get; }

        public async Task<IEnumerable<string>> GetObjectNumberAsync(string key)
        {
            var paintingsAsJson = await ReadApiAsync(key);

            var serializedJson = Deserialize(paintingsAsJson);

            return FilterObjectNumber(serializedJson);
        }

        private static IEnumerable<string> FilterObjectNumber(PaintingSummary output)
        {
            return output.artObjects.Select(o => o.objectNumber);
        }

        private static PaintingSummary Deserialize(string response)
        {
            return JsonConvert.DeserializeObject<PaintingSummary>(response); 
        }

        private async Task<string> ReadApiAsync(string key)
        {
            return await Client.GetStringAsync("https://www.rijksmuseum.nl/api/nl/collection?key=" + key + "&format=json&type=schilderij&toppieces=True");
        }
    }
}

