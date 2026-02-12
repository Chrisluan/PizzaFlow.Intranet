using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFlow.Intranet.Business.CustomExceptions
{
    public class ErroAoExcluirException : BusinessException
    {
        public ErroAoExcluirException(string? message, Exception? innerException)
        : base(message = "Erro ao excluir, cheque a Inner Exception para mais detalhes", innerException)
        {
           
        }
    }
}
