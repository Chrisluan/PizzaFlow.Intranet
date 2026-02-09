namespace PizzaFlow.Intranet.Portal.Extensions.UI.Menu.Models
{
    public class SidebarMenu
    {
        public string Categoria { get; set; }
        public string Icone { get; set; }
        public List<SidebarItem> Itens { get; set; } = new();
    }
    
}
