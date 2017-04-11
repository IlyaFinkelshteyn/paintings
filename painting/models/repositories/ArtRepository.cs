using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using static painting.models.Rijksmuseum;
using System.Threading.Tasks;
using static painting.models.PaintingData;
using painting.ViewModel;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System;

namespace painting.models.repositories
{
    public class objectNumber_Repository : IArtServiceAdapter
    {
        private readonly MyOptions _options;
        
        private static HttpClient Client = new HttpClient();
        private string options;

        public objectNumber_Repository(MyOptions options)
        {
            _options = options;
        }

        public objectNumber_Repository(HttpClient mockedHttpClient)
        {
            Client = mockedHttpClient; 
        }

        private IEnumerable<string> filterObjectNumber(Rijksmuseum.PaintingSummary output)
        {
            return output.artObjects.Select(o => o.objectNumber);
        }

        private Rijksmuseum.PaintingSummary deserialize(string response)
        {
            return JsonConvert.DeserializeObject<PaintingSummary>(response); 
        }

        private async Task<string> readApiAsync()
        {
            return await Client.GetStringAsync("https://www.rijksmuseum.nl/api/nl/collection?key=" + _options.key + "&format=json&type=schilderij&toppieces=True");
        }

       

        public async Task<IEnumerable> GetObjectNumberAsync()
        {
            var paintingsAsJson = await readApiAsync();

            var serializedJSON = deserialize(paintingsAsJson);

            var ObjectNumbers = filterObjectNumber(serializedJSON);

            return ObjectNumbers;
        }
    }
}

