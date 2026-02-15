
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

            if (!Regex.IsMatch(numeroTelefone, "^\\(\\d{2}\\)\\s\\d{5}-\\d{4}$"))
                throw new BusinessException("Telefone deve estar no formato (00) 00000-0000");
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
            if (!nome.ToLower().All(char.IsLetter))
                throw new BusinessException("Nomes podem conter apenas letras.");
        }
    }
}
