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
        private MyOptions options;  

        [Fact]
        public async Task TestIfFunctionReturnIEnumberableObjectNumbersAsync()
        {
            //Arrange 

            var mockHttp = new MockHttpMessageHandler();

            mockHttp.When("https://www.rijksmuseum.nl/*")
                .Respond("application/json", File.ReadAllText("input.json"));

            var Client = mockHttp.ToHttpClient();

            var repo = new objectNumber_Repository(Client);

            var response = await Client.GetStringAsync("https://www.rijksmuseum.nl/api/nl");

            var expected = ("SK-C-5");


            //Act 

            var real = await repo.GetObjectNumberAsync();

            //Assert 

            Assert.Equal(real, expected);


        }
    }
}
