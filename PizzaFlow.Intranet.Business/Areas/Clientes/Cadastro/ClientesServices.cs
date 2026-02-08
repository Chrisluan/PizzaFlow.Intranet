using PizzaFlow.Intranet.Business.PizzaFlowBase.Repository.Interfaces;
using PizzaFlow.Intranet.Infra.PizzaFlowBase.Repository.Interfaces;
using PizzaFlow.Intranet.Models.Clientes;
using PizzaFlow.Intranet.Models.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFlow.Intranet.Business.Areas.Clientes.Cadastro
{
    public class ClientesServices : IClientesServices
    {
        private readonly IClientesRepository dataRepository;
        public ClientesServices() { }
        public void CadastrarNovoCliente(Cliente cliente)
        {
            dataRepository.CadastrarNovoCliente(cliente);
           
        }

        public Task<bool> Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pedido>> PegarHistoricoDePedidoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente?> ProcurarClientePorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> RetornarTodos(int inicio = 0, int? maximo = 0)
        {
            throw new NotImplementedException();
        }

    }
}
