using PizzaFlow.Intranet.Portal.Extensions.UI.Menu.Models;

namespace PizzaFlow.Intranet.Portal.Extensions.UI.Menu
{
    public class ItemBuilder
    {
        private readonly CategoriaBuilder _categoriaBuilder;
        private readonly SidebarItem _item;

        public ItemBuilder(CategoriaBuilder categoriaBuilder, SidebarItem item)
        {
            _categoriaBuilder = categoriaBuilder;
            _item = item;
        }

        public CategoriaBuilder VaiPara(string controller, string action)
        {
            _item.Controller = controller;
            _item.Action = action;
            return _categoriaBuilder;
        }

        public ItemBuilder Sub(string texto, string controller, string action, string icone = null)
        {
            _item.SubItens.Add(new SidebarItem
            {
                Texto = texto,
                Controller = controller,
                Action = action,
                Icone = icone
            });

            return this;
        }
    }


}
