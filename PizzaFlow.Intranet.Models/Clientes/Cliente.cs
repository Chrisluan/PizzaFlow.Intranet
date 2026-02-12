using FluentNHibernate.Automapping;
using PizzaFlow.Intranet.Models.Pedidos;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PizzaFlow.Intranet.Models.Clientes
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NumeroTelefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Endereco { get; set; }
    }

}
