using Painting.Website.Models;
using Painting.Website.Repositories;
using Shouldly;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using WorldDomination.Net.Http;
using Xunit;

namespace Painting.Website.Tests.unit_tests
{
    public class TestInternetConnection
    {
        [Fact]
        public async System.Threading.Tasks.Task TestIfCallToApiWillBe2001Async()
        {
            // Arrange.
            var responseData = File.ReadAllText("Sample Data\\input.json");
            var messageResponse = FakeHttpMessageHandler.GetStringHttpResponseMessage(responseData);
            var options = new HttpMessageOptions
            {
                HttpMethod = HttpMethod.Get,
                RequestUri = "https://www.rijksmuseum.nl/api/nl/collection?key=secret&format=json&type=schilderij&toppieces=True",
                HttpResponseMessage = messageResponse
            };
            var messageHandler = new FakeHttpMessageHandler(options);
            var service = new ObjectNumberRepository(messageHandler);

            // Act.
            var results = (await service.ReadApiAsync("secret")); 

            // Assert.
            options.NumberOfTimesCalled.ShouldBe(0);
            results.ShouldNotBeNull();
        }
    }
}
