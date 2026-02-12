
using Microsoft.IdentityModel.Tokens;
using PizzaFlow.Intranet.Business.CustomExceptions;
using PizzaFlow.Intranet.Models.Clientes;
using System.Security.Policy;
using System.Text.RegularExpressions;
namespace PizzaFlow.Intranet.Business.Areas.Clientes
{
    public static class ValidarCliente
    {
        public static void ValidarNumeroTelefone(string numeroTelefone)
        {
            string regex = "/^(55)?(?:([1-9]{2})?)(\\d{4,5})(\\d{4})$/;";
            if (!Regex.IsMatch(numeroTelefone, regex))
                throw new BusinessException("Número de telefone fora do padrão");
        }
        
        public static void ValidarCompleto(Cliente cliente)
        {
            //ValidarNumeroTelefone(cliente.NumeroTelefone);
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
