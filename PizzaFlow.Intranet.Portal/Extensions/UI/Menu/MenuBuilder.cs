using PizzaFlow.Intranet.Portal.Extensions.UI.Menu;
using PizzaFlow.Intranet.Portal.Extensions.UI.Menu.Models;

public class MenuBuilder
{
    private readonly List<SidebarMenu> _menus = new();

    public static MenuBuilder Criar() => new();

    public CategoriaBuilder Categoria(string nome, string icone = null)
    {
        var categoria = new SidebarMenu
        {
            Categoria = nome,
            Icone = icone
        };

        _menus.Add(categoria);
        return new CategoriaBuilder(this, categoria);
    }

    public List<SidebarMenu> Build() => _menus;
}
