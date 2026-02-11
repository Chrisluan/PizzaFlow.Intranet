using Microsoft.AspNetCore.Mvc;

namespace PizzaFlow.Intranet.Portal.Controllers.Insumos
{
    public class InsumosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View("CadastrarInsumo");
        }
    }
}
