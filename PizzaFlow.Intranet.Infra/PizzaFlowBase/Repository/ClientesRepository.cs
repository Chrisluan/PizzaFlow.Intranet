using PizzaFlow.Intranet.Business.PizzaFlowBase.Repository.Interfaces;
using PizzaFlow.Intranet.Infra.PizzaFlowBase.CustomExceptions;
using PizzaFlow.Intranet.Infra.PizzaFlowBase.Repository.Interfaces;
using PizzaFlow.Intranet.Models.Clientes;
using PizzaFlow.Intranet.Models.Pedidos;

public class ClientesRepository : IClientesRepository
{
    private readonly IDataRepository<Cliente> clienteDataRepository;

    public ClientesRepository(
        IDataRepository<Cliente> clienteDataRepository,
        IDataRepository<Pedido> pedidoDataRepository)
    {
        this.clienteDataRepository = clienteDataRepository;
    }

    public async Task<Cliente?> ProcurarClientePorId(int id)
    {
        return await clienteDataRepository.GetByIdAsync(id);
    }

    public async Task CadastrarNovoCliente(Cliente cliente)
    {
        await clienteDataRepository.AddAsync(cliente);
        await clienteDataRepository.SaveChangesAsync();
    }

    public async Task<bool> Deletar(int id)
    {
        var cliente = await clienteDataRepository.GetByIdAsync(id);
        clienteDataRepository.Delete(cliente);
        await clienteDataRepository.SaveChangesAsync();

        return true;
    }
    public IQueryable<Cliente> QueryClientes()
    {
        return clienteDataRepository.Query();

    }

}
