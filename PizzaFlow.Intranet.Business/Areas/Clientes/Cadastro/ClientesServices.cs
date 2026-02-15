using NHibernate.Criterion;
using PizzaFlow.Intranet.Infra.PizzaFlowBase.Repository.Interfaces;
using PizzaFlow.Intranet.Models.Clientes;

namespace PizzaFlow.Intranet.Business.Areas.Clientes.Cadastro
{
    public class ClientesServices : IClientesServices
    {
        private readonly IClientesRepository _clienteRepository;
        public ClientesServices(IClientesRepository clientesRepository) {
            _clienteRepository = clientesRepository;
        }

        public void Atualizar(Cliente cliente)
        {
            ValidarCliente.ValidarCompleto(cliente);
            _clienteRepository.AtualizarCliente(cliente);
        }

        public Cliente ProcurarPorId(int id)
        {
            Cliente? clienteEncontrado = _clienteRepository.ProcurarClientePorId(id);
            ValidarCliente.ValidarCompleto(clienteEncontrado); 
            return clienteEncontrado;
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void Novo(Cliente cliente)
        {
            if(cliente == null) throw new ArgumentNullException(nameof(cliente));
            ValidarCliente.ValidarCompleto(cliente);

            _clienteRepository.CadastrarNovoCliente(cliente);
        }

        public IQueryable<Cliente> RetornarTodos()
        {
            
            return _clienteRepository.QueryClientes();
        }
    }
}
