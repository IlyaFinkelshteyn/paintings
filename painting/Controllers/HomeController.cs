using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using painting.models;
using painting.models.repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace painting.Controllers
{
    public class HomeController : Controller
    {
        private MyOptions _options;

        public HomeController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        public async Task<IActionResult> Index()
        {
            var service = new objectNumber_Repository(_options);
            var numbers = await service.GetObjectNumberAsync(); 

            //var data = await service.GetDataPaintingsAsync(numbers);


            return View(numbers);
        }



        public IActionResult Error()
        {
            return View();
        }
    }
}
