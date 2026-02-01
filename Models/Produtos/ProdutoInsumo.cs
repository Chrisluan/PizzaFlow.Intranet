namespace PizzaFlow.Intranet.Models.Produtos
{
    public class ProdutoInsumo
    {
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int InsumoId { get; set; }
        public Insumo Insumo { get; set; }

        public decimal? QuantidadeUsada { get; set; }
    }

}
