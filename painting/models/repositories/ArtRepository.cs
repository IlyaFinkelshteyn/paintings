using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using static painting.models.Rijksmuseum;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json.Serialization;
using static painting.models.PaintingData;
using painting.ViewModel;

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
            return output.ArtObjects.Select(o => o.objectNumber);
        }

        private static PaintingSummary Deserialize(string response)
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return JsonConvert.DeserializeObject<PaintingSummary>(response, serializerSettings); 
        }

        private async Task<string> ReadApiAsync(string key)
        {
            return await Client.GetStringAsync("https://www.rijksmuseum.nl/api/nl/collection?key=" + key + "&format=json&type=schilderij&toppieces=True");
        }

        public async Task<IEnumerable<painting.ViewModel.PaintingViewModel>> GetDataPaintingsAsync(IEnumerable<string> numbers, string key)
        {
            var Paintings2 = new List<PaintingViewModel>();  //make a empty list that will contain all the object that must be send to the View 

            foreach (var item in numbers)
            {
                var response = await ReadDataImageAsync(item, key); //Read the data from the api-endpoint
                var response2 = await ReadImageUrlAsync(item, key); // Read the imageurls from another api-endpoint 

                var deserializedData = deserializeData(response); // deserialize the data from the api-endpoint 
                var deserializedImage = deserializeImage(response2); //deserialize the imageurls from the api-endpoint 

                var painting = FilterDataAndImage(deserializedData, deserializedImage); //Filter the data out that I need 

                Paintings2.Add(painting); //add the new object to the list
            }

            return Paintings2; // return the new list so I can be passed on to the view 
        }

        private PaintingViewModel FilterDataAndImage(Painting paintingsData, Image.Image2 imageUrlData)
        {
            var name = paintingsData.artObject.principalMakers[0].name;
            var title = paintingsData.artObject.title;
            var description = paintingsData.artObject.description;
            var year = paintingsData.artObject.dating.year;
            var collection = paintingsData.artObject.objectCollection[0];
            var colors = paintingsData.artObject.colors;
            var image = imageUrlData.levels[4].tiles;


            return new PaintingViewModel(name, title, description, year, collection, colors, image);

        }

        private Image.Image2 deserializeImage(string imageURLAsJSON)
        {
            return JsonConvert.DeserializeObject<Image.Image2>(imageURLAsJSON);
        }

        private Painting deserializeData(string dataAsJson)
        {
            return JsonConvert.DeserializeObject<Painting>(dataAsJson);
        }

        private async Task<string> ReadImageUrlAsync(string item, string key)
        {
            return await Client.GetStringAsync(("https://www.rijksmuseum.nl/api/nl/collection/" + item + "/tiles?key="  + key + "&format=json"));
        }

        private async Task<string> ReadDataImageAsync(string item,  string key)
        {
            return await Client.GetStringAsync(("https://www.rijksmuseum.nl/api/nl/collection/" + item + "?key="  + key + "&format=json"));
                 
        }
    }
}

