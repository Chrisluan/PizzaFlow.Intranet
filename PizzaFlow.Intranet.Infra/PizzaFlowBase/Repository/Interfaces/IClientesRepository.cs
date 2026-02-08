using PizzaFlow.Intranet.Models.Clientes;
using PizzaFlow.Intranet.Models.Pedidos;

namespace PizzaFlow.Intranet.Infra.PizzaFlowBase.Repository.Interfaces
{
    public interface IClientesRepository
    {
        Task<Cliente?> ProcurarClientePorId(int id);
        IQueryable<Cliente> QueryClientes();
        Task CadastrarNovoCliente(Cliente cliente);
        Task<bool> Deletar(int id);
        
    }
}
