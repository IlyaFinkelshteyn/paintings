using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Painting.Website.ViewModel;
using System;
using Painting.Website.Models;

namespace Painting.Website.Repositories
{
    public class ObjectNumberRepository : IArtServiceAdapter
    {
        private static HttpClient _httpClient;

        public ObjectNumberRepository(HttpClientHandler httpClientHandler = null)
        {
            // We have 1x instance of the httpclient, always.
            // That said, do we hit a real endpoint on the internet OR do we just
            // provide some fake response data, given some hard-coded request details
            // (which is what we would do if this was a unit-test).
            _httpClient = httpClientHandler == null
                ? new HttpClient()
                : new HttpClient(httpClientHandler);
        }
        
        public async Task<string> ReadApiAsync(string key)
        {
            return await _httpClient.GetStringAsync("https://www.rijksmuseum.nl/api/nl/collection?key=" + key + "&format=json&type=schilderij&toppieces=True");
        }

        public async Task<IEnumerable<PaintingViewModel>> GetDataPaintingsAsync(IEnumerable<string> numbers, string key)
        {

            var tasks = new List<Task<PaintingViewModel>>();

            foreach(string number in numbers) {
                // Initiate each download
                tasks.Add(GetPaintingViewModelAsync(number, key));
            }

            // Await all results
            var paintings = await Task.WhenAll(tasks);

            return paintings;
        }

        private async Task<PaintingViewModel> GetPaintingViewModelAsync(string number, string key) {
            // Start both Tasks to fetch the data
            var t1 = ReadDataImageAsync(number, key);
            var t2 = ReadImageUrlAsync(number, key);

            // Wait till both completes
            await Task.WhenAll(t1, t2);

            var response = await t1;
            var response2 = await t2;

            // Compute the other stuff, since this is CPU bound no others Tasks are needed
            var deserializedData = deserializeData(response); // deserialize the data from the api-endpoint 
            var deserializedImage = deserializeImage(response2); //deserialize the imageurls from the api-endpoint 

            var painting = FilterDataAndImage(deserializedData, deserializedImage); //Filter the data out that I need 

            return painting;
        }

        private PaintingViewModel FilterDataAndImage(PaintingData.Painting paintingsData, Image.Image2 imageUrlData)
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

        private PaintingData.Painting deserializeData(string dataAsJson)
        {
            return JsonConvert.DeserializeObject<PaintingData.Painting>(dataAsJson);
        }

        private async Task<string> ReadImageUrlAsync(string item, string key)
        {
            return await _httpClient.GetStringAsync(("https://www.rijksmuseum.nl/api/nl/collection/" + item + "/tiles?key="  + key + "&format=json"));
        }

        private async Task<string> ReadDataImageAsync(string item,  string key)
        {
            return await _httpClient.GetStringAsync(("https://www.rijksmuseum.nl/api/nl/collection/" + item + "?key="  + key + "&format=json"));
                 
        }

        //Task<IEnumerable<PaintingViewModel>> IArtServiceAdapter.GetDataPaintingsAsync(IEnumerable<string> numbers, string key)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

