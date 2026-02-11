using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PizzaFlow.Intranet.Models.Produtos
{
    public class Insumo
    {
        public Guid Id { get; set; }
        public string Handle { get; set; }
        public string Nome { get; set; }

        [DisplayName("Valor adicional")]
        public decimal? ValorAdicional { get; set; }

        public int CategoriaInsumoId { get; set; }
        //public CategoriaInsumo CategoriaInsumo { get; set; }

        public ICollection<ProdutoInsumo> ProdutoInsumos { get; set; }
    }

}
