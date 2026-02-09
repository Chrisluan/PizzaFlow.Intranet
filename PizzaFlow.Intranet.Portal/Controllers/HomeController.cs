using Microsoft.AspNetCore.Mvc;

namespace PizzaFlow.Intranet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            
            _logger = logger;
        }
        public IActionResult Privacy()
        {
            return View("Privacy");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
