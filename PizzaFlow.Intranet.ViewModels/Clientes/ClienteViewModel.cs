
using PizzaFlow.Intranet.Models.Clientes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;


namespace PizzaFlow.Intranet.ViewModels.Clientes
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [DisplayName("Nome do Cliente")]
        [Required]
        public string Nome { get; set; }

        [DisplayName("Numero de Telefone")]
        [Required]
        public string NumeroTelefone { get; set; }

        [DisplayName("Aniversário")]
        public DateTime? DataNascimento { get; set; }

        [DisplayName("Endereço")]
        public string? Endereco { get; set; }
    }

}
