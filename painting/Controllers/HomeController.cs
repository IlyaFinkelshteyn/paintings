using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using painting.models;
using painting.models.repositories;
using Microsoft.Extensions.Options;

namespace painting.Controllers
{
    public class HomeController : Controller
    {
        private static readonly HttpClient Client = new HttpClient();

        private readonly MyOptions _options;

        public HomeController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        public async Task<IActionResult> Index()
        {
            var service = new ObjectNumberRepository();

            var numbers = await service.GetObjectNumberAsync(_options.key);

            var data = await service.GetDataPaintingsAsync(numbers, _options.key);

            return View(data);
            
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
