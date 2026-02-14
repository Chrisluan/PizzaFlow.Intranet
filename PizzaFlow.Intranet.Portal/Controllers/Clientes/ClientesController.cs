using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Mapping.ByCode.Impl;
using PizzaFlow.Intranet.Business.Areas.Clientes.Cadastro;
using PizzaFlow.Intranet.Infra.PizzaFlowBase.Repository.Interfaces;
using PizzaFlow.Intranet.Models.Clientes;
using PizzaFlow.Intranet.Models.Produtos;
using PizzaFlow.Intranet.ViewModels.Clientes;

namespace PizzaFlow.Intranet.Portal.Controllers.Clientes
{
    public class ClientesController : Controller
    {
        private readonly IClientesServices _clientesServices;
        private readonly IMapper _mapper;
        public ClientesController(IClientesServices clientesServices, IMapper mapper)
        {
            _mapper = mapper;
            _clientesServices = clientesServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cadastrados()
        {
            List<Cliente> todos = _clientesServices.RetornarTodos().Take(100).ToList();
            var todosMapeados = _mapper.Map<List<Cliente>, List<ClienteViewModel>>(todos);

            return View("VisualizarClientes", todosMapeados);
        }
        public IActionResult Cadastrar() {

            return View("CadastrarCliente");
        }
      
        public IActionResult Salvar(ClienteViewModel cliente)
        {
            if (!ModelState.IsValid)
            {
                return View("CadastrarCliente", cliente);
            }
                
            var clienteModel = _mapper.Map<ClienteViewModel, Cliente>(cliente);
            _clientesServices.Novo(clienteModel);

            return Cadastrados();
        }
    }
}
