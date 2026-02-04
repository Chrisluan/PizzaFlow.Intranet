namespace PizzaFlow.Intranet.Models.Produtos
{
    public class Produto
    {
        public int Id { get; set; }
        public string Handle { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public int CategoriaId { get; set; }
        //public CategoriaProduto Categoria { get; set; }

        public int? TempoMedioProntoMinutos { get; set; }

        public ICollection<ProdutoInsumo> ProdutoInsumos { get; set; }
    }

}
