using Microsoft.AspNetCore.Mvc;
using PizzaFlow.Intranet.Business.Areas.Clientes.Cadastro;
using PizzaFlow.Intranet.Models.Clientes;
using System.Collections;

namespace PizzaFlow.Intranet.Portal.Controllers.Clientes
{
    public class VisualizarClientes : Controller
    {
        private readonly IClientesServices _clientesServices;
        public VisualizarClientes(IClientesServices clientesServices)
        {
            _clientesServices = clientesServices;
        }

        
    }
}
