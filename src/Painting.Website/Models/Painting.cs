using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Painting.Website.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Painting.Website.Models
{
    public class Painting
    {
        public async Task<IEnumerable<string>> GetObjectNumberAsync(string key)
        {
            var service = new ObjectNumberRepository();
            var paintingsAsJson = await service.ReadApiAsync(key);

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
