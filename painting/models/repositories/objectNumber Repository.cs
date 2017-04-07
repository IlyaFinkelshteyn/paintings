using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using static painting.models.Rijksmuseum;
using System;
using System.Threading.Tasks;

namespace painting.models.repositories
{
    public class objectNumber_Repository : objectNumberInterface 
    {
        private static HttpClient Client = new HttpClient();

        public async Task<IEnumerable> GetDataPaintingsAsync(IEnumerable objectnumbers)
        {
            foreach (var objectnumber in objectnumbers)
            {
                string response = await Client.GetStringAsync("https://www.rijksmuseum.nl/api/nl/collection/" + objectnumber + "?key=14OGzuak&format=json");

                var output = JsonConvert.DeserializeObject<Rootobject>(response);

                var objectNumber = 1; 

                
            }

            return new List<int>();

        }

        public async Task<IEnumerable> GetObjectNumberAsync()
        {
            string response = await Client.GetStringAsync("https://www.rijksmuseum.nl/api/nl/collection?key=14OGzuak&format=json&type=schilderij&toppieces=True");

            var output = JsonConvert.DeserializeObject<Rootobject>(response);

            var numbers = output.artObjects.Select(o => o.objectNumber);

            return numbers;
        }
    }
}

