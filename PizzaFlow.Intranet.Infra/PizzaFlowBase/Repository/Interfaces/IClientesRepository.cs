using PizzaFlow.Intranet.Models.Clientes;
using PizzaFlow.Intranet.Models.Pedidos;

namespace PizzaFlow.Intranet.Infra.PizzaFlowBase.Repository.Interfaces
{
    public interface IClientesRepository
    {
        Cliente? ProcurarClientePorId(int id);
        IQueryable<Cliente> QueryClientes();
        void CadastrarNovoCliente(Cliente cliente);
        bool Deletar(int id);
        
    }
}
