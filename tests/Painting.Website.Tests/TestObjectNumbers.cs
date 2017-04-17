using Xunit;
using System.Threading.Tasks;
using WorldDomination.Net.Http;
using System.IO;
using Painting.Website.Repositories;
using System.Net.Http;

namespace Painting.Website.Tests
{
    public class TestObjectNumbers
    {
        [Fact]
        public async Task TestIfFunctionReturnIEnumberableObjectNumbersAsync()
        {
            // Fake response.
            var responseData = File.ReadAllText("Sample Data\\input.json");
            var messageResponse = FakeHttpMessageHandler.GetStringHttpResponseMessage(responseData);
            var repo = new ObjectNumberRepository();

            var options = new HttpMessageOptions
            {
                RequestUri = "https://www.rijksmuseum.nl/api/nl/collection?key=secret&format=json&type=schilderij&toppieces=True", 
                HttpResponseMessage = messageResponse
            };

            var messageHandler = new FakeHttpMessageHandler(options);

            // Act 
            var result = await repo.GetObjectNumberAsync("secret");



        }
    }
}
