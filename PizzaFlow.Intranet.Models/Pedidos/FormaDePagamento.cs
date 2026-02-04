namespace PizzaFlow.Intranet.Models.Pedidos
{
    public class FormaPagamento
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }

    public class PedidoFormaPagamento
    {
        public Guid Id { get; set; }

        public Guid PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public Guid FormaPagamentoId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }

        public decimal ValorPago { get; set; }
    }


}
