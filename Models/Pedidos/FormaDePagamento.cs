namespace PizzaFlow.Intranet.Models.Pedidos
{
    public class FormaPagamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class PedidoFormaPagamento
    {
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public int FormaPagamentoId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }

        public decimal ValorPago { get; set; }
    }

}
