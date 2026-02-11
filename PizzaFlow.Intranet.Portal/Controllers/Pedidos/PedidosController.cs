using Microsoft.AspNetCore.Mvc;

namespace PizzaFlow.Intranet.Portal.Controllers.Pedidos
{
    public class PedidosController : Controller
    {
        public IActionResult Index()
        {
            return View("Pedidos");
        }
        public IActionResult NovoPedido()
        {
            return View("NovoPedido");
        }
    }
}
