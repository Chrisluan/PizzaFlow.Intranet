namespace PizzaFlow.Intranet.Models.Produtos
{
    public class ProdutoInsumo
    {
        public Guid Id { get; set; }

        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public Guid InsumoId { get; set; }
        public Insumo Insumo { get; set; }

        public decimal QuantidadeUsada { get; set; }
    }


}
