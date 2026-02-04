using PizzaFlow.Intranet.Business.PizzaFlowBase.Repository.Interfaces;
using PizzaFlow.Intranet.Models.Clientes;
using PizzaFlow.Intranet.Models.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFlow.Intranet.Infra.PizzaFlowBase.Repository.Interfaces
{
    public interface IClientesRepository
    {
        public Cliente ProcurarClientePorId(int id);
        public IEnumerable<Pedido> PegarHistoricoDePedidoPorId(int id);
        public void CadastrarNovoCliente(Cliente cliente);
        
    }
}
