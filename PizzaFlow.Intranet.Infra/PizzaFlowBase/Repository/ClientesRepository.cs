using PizzaFlow.Intranet.Business.PizzaFlowBase.Repository;
using PizzaFlow.Intranet.Business.PizzaFlowBase.Repository.Interfaces;
using PizzaFlow.Intranet.Infra.PizzaFlowBase.Repository.Interfaces;
using PizzaFlow.Intranet.Models.Clientes;
using PizzaFlow.Intranet.Models.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFlow.Intranet.Infra.PizzaFlowBase.Repository
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly IDataRepository<Cliente> clienteDataRepository;
        private readonly IDataRepository<Pedido> pedidoDataRepository;
        public ClientesRepository(IDataRepository<Cliente> clienteDataRepository, IDataRepository<Pedido> pedidoDataRepository) {
            this.clienteDataRepository = clienteDataRepository;
            this.pedidoDataRepository = pedidoDataRepository;

        }
        public void CadastrarNovoCliente(Cliente cliente) => clienteDataRepository.AddAsync(cliente);

        public IEnumerable<Pedido> PegarHistoricoDePedidoClientePorId(int idCliente) {
            var pedidos = pedidoDataRepository.GetAllAsync().Result.Where(c => c.ClienteId == idCliente);
            return pedidos;
        }

        public Cliente ProcurarClientePorId(int id)
        {
            
        }
    }
}
