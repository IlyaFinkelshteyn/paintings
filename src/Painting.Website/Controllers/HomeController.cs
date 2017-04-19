using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Painting.Website.Models;
using Painting.Website.Repositories;
using Microsoft.Extensions.Options;

namespace Painting.Website.Controllers
{
    public class HomeController : Controller
    {

        private readonly MyOptions _options;
        private readonly IPaintings _painting;

        public HomeController(IPaintings painting, IOptions<MyOptions> optionsAccessor)
        {
            _painting = painting;
            _options = optionsAccessor.Value;
        }


        public async Task<IActionResult> Index()
        {
            var numbers = await _painting.GetObjectNumberAsync(_options.key);

            //var data = await service.GetDataPaintingsAsync(numbers, _options.key);

            return View(numbers);
            
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
