using PizzaFlow.Intranet.Models.Clientes;
using PizzaFlow.Intranet.Models.Usuarios;

namespace PizzaFlow.Intranet.Models.Pedidos
{
    public class Pedido
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public DateTime DataHoraPedido { get; set; }
        public DateTime? DataHoraFinalizado { get; set; }

        public StatusPedido Status { get; set; }

        public decimal ValorTotal { get; set; }

        public ICollection<ItemPedido> Itens { get; set; }
        public ICollection<PedidoFormaPagamento> FormasPagamento { get; set; }
    }

}
