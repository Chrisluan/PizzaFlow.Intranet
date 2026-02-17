using PizzaFlow.Intranet.Business.PizzaFlowBase.Repository.Interfaces;
using PizzaFlow.Intranet.Infra.PizzaFlowBase.Repository.Interfaces;
using PizzaFlow.Intranet.Models.Clientes;
using PizzaFlow.Intranet.Models.Pedidos;

public class ClientesRepository : IClientesRepository
{
    private readonly IDataRepository<Cliente> clienteDataRepository;

    public ClientesRepository(
        IDataRepository<Cliente> clienteDataRepository)
    {
        this.clienteDataRepository = clienteDataRepository;
    }

    public Cliente? ProcurarClientePorId(int id)
    {
        return clienteDataRepository.GetById(id);
    }

    public void CadastrarNovoCliente(Cliente cliente)
    {
        clienteDataRepository.Add(cliente);
        clienteDataRepository.SaveChanges();
    }


    public void AtualizarCliente(Cliente cliente)
    {
        clienteDataRepository.Update(cliente);
        clienteDataRepository.SaveChanges();
    }

    public bool Deletar(int id)
    {
        var cliente = clienteDataRepository.GetById(id);
        clienteDataRepository.Delete(cliente);
        clienteDataRepository.SaveChanges();

        return true;
    }
    public IQueryable<Cliente> QueryClientes()
    {
        return clienteDataRepository.Query();

    }

}
