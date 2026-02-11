using FluentNHibernate.Automapping;
using PizzaFlow.Intranet.Models.Pedidos;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PizzaFlow.Intranet.Models.Clientes
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [AllowNull]
        public string Handle { get; set; }
        [DisplayName("Nome do Cliente")]
        [Required]
        public string Nome { get; set; }
        [DisplayName("Numero de Telefone")]
        [Required]
        public string NumeroTelefone { get; set; }
        [DisplayName("Aniversário")]

        [AllowNull]
        public DateTime? DataNascimento { get; set; }

        
        [DisplayName("Endereço")]
        [AllowNull]
        public string Endereco { get; set; }
    }

}
