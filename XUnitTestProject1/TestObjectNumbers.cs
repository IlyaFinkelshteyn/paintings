using painting.models.repositories;
using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using painting.models;
using System.Collections;
using System.Threading.Tasks;

namespace TestPaintings
{
    public class TestObjectNumbers
    {
        [Fact]
        public async Task TestIfFunctionReturnIEnumberableObjectNumbersAsync()
        {
            //Arrange 
            var mockHttp = new MockHttpMessageHandler();

            mockHttp.When("https://www.rijksmuseum.nl/*")
                .Respond("application/json", File.ReadAllText("input.json"));

            var client = mockHttp.ToHttpClient();

            var repo = new ObjectNumberRepository(client);

            //Act 
            var real = await repo.GetObjectNumberAsync("SK-C-5");

            //Assert 

        }
    }
}
