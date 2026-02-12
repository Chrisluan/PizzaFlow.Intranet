namespace PizzaFlow.Intranet.Business.CustomExceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string? message, Exception? innerException = null) : base(message, innerException)
        {
        }
    }
}
