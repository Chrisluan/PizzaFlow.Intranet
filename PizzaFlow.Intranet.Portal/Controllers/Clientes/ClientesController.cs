using Microsoft.AspNetCore.Mvc;
using PizzaFlow.Intranet.Infra.PizzaFlowBase.Repository.Interfaces;
using PizzaFlow.Intranet.Models.Clientes;
using PizzaFlow.Intranet.Models.Produtos;

namespace PizzaFlow.Intranet.Portal.Controllers.Clientes
{
    public class ClientesController : Controller
    {
        private readonly IClientesRepository _clientesRepository;
        public ClientesController(IClientesRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastrar() {

            return View("CadastrarCliente");
        }
      
        public async Task<IActionResult> Salvar(Cliente cliente)
        {
            cliente.Handle = Guid.NewGuid().ToString();
            await _clientesRepository.CadastrarNovoCliente(cliente);


            return View("CadastrarCliente");
        }
    }
}
