using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Mapping.ByCode.Impl;
using PizzaFlow.Intranet.Infra.PizzaFlowBase.Repository.Interfaces;
using PizzaFlow.Intranet.Models.Clientes;
using PizzaFlow.Intranet.Models.Produtos;
using PizzaFlow.Intranet.ViewModels.Clientes;

namespace PizzaFlow.Intranet.Portal.Controllers.Clientes
{
    public class ClientesController : Controller
    {
        private readonly IClientesRepository _clientesRepository;
        private readonly IMapper _mapper;
        public ClientesController(IClientesRepository clientesRepository, IMapper mapper)
        {
            _mapper = mapper;
            _clientesRepository = clientesRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastrar() {

            return View("CadastrarCliente");
        }
      
        public IActionResult Salvar(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
                return View("CadastrarCliente", cliente);
            var clienteModel = _mapper.Map<ClienteViewModel, Cliente>(cliente);
            _clientesRepository.CadastrarNovoCliente(clienteModel);

            return View("CadastrarCliente", null);
        }
    }
}
