using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFlow.Intranet.Infra.PizzaFlowBase.CustomExceptions
{
    public class ErroAoExcluirException : Exception
    {
        public ErroAoExcluirException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
