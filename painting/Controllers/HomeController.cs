using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using painting.models.repositories;

namespace painting.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            var service = new objectNumber_Repository();
            var numbers = await service.GetObjectNumberAsync(); 

            var data = await service.GetDataPaintingsAsync(numbers);

            return View(numbers);
        }



        public IActionResult Error()
        {
            return View();
        }
    }
}
