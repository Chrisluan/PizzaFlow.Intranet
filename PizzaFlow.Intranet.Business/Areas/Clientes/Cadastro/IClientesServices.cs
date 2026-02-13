using PizzaFlow.Intranet.Infra.PizzaFlowBase.Repository.Interfaces;
using PizzaFlow.Intranet.Models.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFlow.Intranet.Business.Areas.Clientes.Cadastro
{
    public interface IClientesServices
    {

        public void Novo(Cliente cliente);
        public void Excluir(int id);
        public void Atualizar(Cliente cliente);
        public IQueryable RetornarTodos();

    }
}
