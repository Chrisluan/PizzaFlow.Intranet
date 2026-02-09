
using PizzaFlow.Intranet.Portal.Extensions.UI.Menu.Models;
using System.Reflection.Emit;

namespace PizzaFlow.Intranet.Portal.Extensions.UI.Menu
{
    public class CategoriaBuilder
    {
        private readonly MenuBuilder _menuBuilder;
        private readonly SidebarMenu _categoria;

        public CategoriaBuilder(MenuBuilder menuBuilder, SidebarMenu categoria)
        {
            _menuBuilder = menuBuilder;
            _categoria = categoria;
        }

        public ItemBuilder Item(string texto, string icone = null)
        {
            var item = new SidebarItem
            {
                Texto = texto,
                Icone = icone
            };

            _categoria.Itens.Add(item);
            return new ItemBuilder(this, item);
        }

        public CategoriaBuilder Categoria(string nome, string icone = null)
         => _menuBuilder.Categoria(nome, icone);

    }


}
