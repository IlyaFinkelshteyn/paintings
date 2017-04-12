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

            var expected = new List<string> { "SK-A-3148", "SK-C-1367", "SK-A-4691", "SK-A-742", "SK-A-2005", "SK-A-4688"
            , "SK-A-4981", "NG-2010-39", "NG-2010-41", "NG-2010-38" };  

            //Act 
            var real = await repo.GetObjectNumberAsync("SK-C-5");
            
           
            //Assert 

            Assert.Equal( expected , real) ; 
            
        }
    }
}
