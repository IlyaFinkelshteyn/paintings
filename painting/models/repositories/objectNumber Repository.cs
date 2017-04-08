using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using static painting.models.Rijksmuseum;
using System;
using System.Threading.Tasks;
using static painting.models.PaintingData;
using painting.ViewModel;

namespace painting.models.repositories
{
    public class objectNumber_Repository : objectNumberInterface 
    {
        private static HttpClient Client = new HttpClient();

        public List<PaintingViewModel> Paintings { get; private set; }
        

        public async Task<IEnumerable> GetDataPaintingsAsync(IEnumerable objectnumbers)
        {
            var Paintings2 = new List<PaintingViewModel>();

            foreach (var objectnumber in objectnumbers)
            {
                string response = await Client.GetStringAsync("https://www.rijksmuseum.nl/api/nl/collection/" + objectnumber + "?key=14OGzuak&format=json");
                string response2 = await Client.GetStringAsync("https://www.rijksmuseum.nl/api/nl/collection/" + objectnumber + "/tiles?key=14OGzuak&format=json"); 
                
                var output = JsonConvert.DeserializeObject<Painting>(response);
                var output2 = JsonConvert.DeserializeObject<Image.Image2>(response2);

                var name = output.artObject.principalMakers[0].name;
                var title = output.artObject.title;
                var description = output.artObject.description;
                var year = output.artObject.dating.year;
                var collection = output.artObject.objectCollection[0];
                var colors = output.artObject.colors;
                var image = output2.levels[4].tiles[0].url;


                var painting = new PaintingViewModel(name, title, description, year, collection, colors, image);
                
                Paintings2.Add(painting); 
                
            }

            return Paintings2;

        }
       
        public async Task<IEnumerable> GetObjectNumberAsync()
        {
            string response = await Client.GetStringAsync("https://www.rijksmuseum.nl/api/nl/collection?key=14OGzuak&format=json&type=schilderij&toppieces=True");

            var output = JsonConvert.DeserializeObject<ObjectNumber>(response);

            var numbers = output.artObjects.Select(o => o.objectNumber);

            return numbers;
        }
    }
}

