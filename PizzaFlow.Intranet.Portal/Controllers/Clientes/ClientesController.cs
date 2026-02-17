using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using NToastNotify;
using PizzaFlow.Intranet.Business.Areas.Clientes.Cadastro;
using PizzaFlow.Intranet.Models.Clientes;
using PizzaFlow.Intranet.ViewModels.Clientes;

namespace PizzaFlow.Intranet.Portal.Controllers.Clientes
{
    public class ClientesController : Controller
    {
        private readonly IClientesServices _clientesServices;
        private readonly IToastNotification _toastNotification;
        private readonly IMapper _mapper;
        public ClientesController(IClientesServices clientesServices, IMapper mapper, IToastNotification toastNotification)
        {
            _mapper = mapper;
            _clientesServices = clientesServices;
            _toastNotification = toastNotification; 
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cadastrados()
        {
            try
            {
                List<Cliente> todos = _clientesServices.RetornarTodos().Take(100).ToList();
                var todosMapeados = _mapper.Map<List<Cliente>, List<ClienteViewModel>>(todos);
                return View("VisualizarClientes", todosMapeados);
            }
            catch (Exception ex) {
                if (ex.GetType() == typeof(SqlException)) {
                    _toastNotification.AddSuccessToastMessage(ex.Message, new ToastrOptions
                    {
                        Title = "Erro no Banco de dados"
                    });
                }
                return View("Home");

            } 
        }
        public IActionResult Cadastrar() {

            return View("CadastrarCliente");
        }
      
        public IActionResult Salvar(ClienteViewModel cliente)
        {
            if (!ModelState.IsValid)
            {
                return View("CadastrarCliente");
            }
            
            var clienteModel = _mapper.Map<ClienteViewModel, Cliente>(cliente);
            try
            {
                _clientesServices.Novo(clienteModel);
                _toastNotification.AddSuccessToastMessage("Cliente cadastrado", new ToastrOptions
                {
                    Title = "Sucesso"
                });
                return RedirectToAction("Cadastrados");
            }
            catch (Exception e)
            {
                _toastNotification.AddErrorToastMessage(e.Message,
                   new ToastrOptions
                   {
                       Title = "Erro ao cadastrar o cliente"
                   });
            }
            return View("CadastrarCliente");
        }
        
        public IActionResult Editar(int id)
        {
            var cliente = _clientesServices.ProcurarPorId(id);
            var clienteMapeado = _mapper.Map<Cliente, ClienteViewModel>(cliente);
            
            return View(clienteMapeado);
        }

        public IActionResult ConfirmarEdicao(ClienteViewModel cliente)
        {
            var clienteMapeado = _mapper.Map<ClienteViewModel, Cliente>(cliente);
            try
            {
                _clientesServices.Atualizar(clienteMapeado);
                _toastNotification.AddSuccessToastMessage("Cliente atualizado", new ToastrOptions
                {
                    Title = "Sucesso"
                });
            }
            catch (Exception e)
            {
                _toastNotification.AddErrorToastMessage(e.Message,
                    new ToastrOptions
                    {
                        Title = "Erro ao atualizar o cliente"
                    });
                return RedirectToAction("Editar", cliente);
            }
            return RedirectToAction("Cadastrados");
        }

        public IActionResult Excluir(int id)
        {
            try
            {
                _clientesServices.Excluir(id);
                return RedirectToAction("Cadastrados");
            }catch(Exception e)
            {
                _toastNotification.AddErrorToastMessage(e.Message, new ToastrOptions
                {
                    Title = "Erro ao atualizar o cliente"
                });
                return RedirectToAction("Cadastrados");
            }


        }
    }
}
