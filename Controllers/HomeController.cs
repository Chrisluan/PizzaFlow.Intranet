using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PizzaFlow.Intranet.Models;

namespace PizzaFlow.Intranet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
