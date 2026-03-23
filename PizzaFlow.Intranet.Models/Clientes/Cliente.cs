

using PizzaFlow.Intranet.Models.Commons;

namespace PizzaFlow.Intranet.Models.Clientes
{
    public class Cliente : EntityBase
    {
        public string Nome { get; set; }
        public string NumeroTelefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Endereco { get; set; }
    }

}
