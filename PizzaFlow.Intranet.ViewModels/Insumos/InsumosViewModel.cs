

using PizzaFlow.Intranet.Models.Produtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFlow.Intranet.ViewModels.Insumos
{
    public class InsumosViewModel
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
