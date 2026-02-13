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

        public void Atualizar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void Novo(Cliente cliente)
        {
            if(cliente == null) throw new ArgumentNullException(nameof(cliente));
            ValidarCliente.ValidarCompleto(cliente);

            dataRepository.CadastrarNovoCliente(cliente);
        }

        public IQueryable RetornarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
