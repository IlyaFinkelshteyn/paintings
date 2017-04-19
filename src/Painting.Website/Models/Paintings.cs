using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Painting.Website.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Painting.Website.Models
{
    public class Paintings : IPaintings 
    {
        private IArtServiceAdapter _service;

        public Paintings(IArtServiceAdapter service)
        {
            _service = service;        
        }

        public async Task<IEnumerable<string>> GetObjectNumberAsync(string key)
        {
            var paintingsAsJson = await  _service.ReadApiAsync(key);

            var serializedJson = Deserialize(paintingsAsJson);

            return FilterObjectNumber(serializedJson);
        }

        public static IEnumerable<string> FilterObjectNumber(Rijksmuseum.PaintingSummary output)
        {
            return output.ArtObjects.Select(o => o.objectNumber);
        }

        public static Rijksmuseum.PaintingSummary Deserialize(string response)
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return JsonConvert.DeserializeObject<Rijksmuseum.PaintingSummary>(response, serializerSettings);
        }
    }
}
