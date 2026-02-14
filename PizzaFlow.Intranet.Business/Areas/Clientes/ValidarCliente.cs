
using Microsoft.IdentityModel.Tokens;
using PizzaFlow.Intranet.Business.CustomExceptions;
using PizzaFlow.Intranet.Models.Clientes;
using System.Text.RegularExpressions;
namespace PizzaFlow.Intranet.Business.Areas.Clientes
{
    public static class ValidarCliente
    {
        public static void ValidarNumeroTelefone(string numeroTelefone)
        {
            if (String.IsNullOrEmpty(numeroTelefone))
                throw new BusinessException("Número de telefone fora do padrão");
        }
        
        public static void ValidarCompleto(Cliente? cliente)
        {
            if (cliente == null) throw new NullReferenceException($"Objeto {typeof(Cliente)} nulo.");
            ValidarNumeroTelefone(cliente.NumeroTelefone);
            ValidarNome(cliente.Nome);
        }
        
        public static void ValidarNome(string nome) {
            if (nome.IsNullOrEmpty())
                throw new BusinessException("O campo Nome precisa ser preenchido.");
            if (!nome.All(char.IsAscii))
                throw new BusinessException("Nomes podem conter apenas letras.");
        }
    }
}
