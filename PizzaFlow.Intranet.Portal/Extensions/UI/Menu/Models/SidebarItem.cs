namespace PizzaFlow.Intranet.Portal.Extensions.UI.Menu.Models
{
    public class SidebarItem
    {
        public string Texto { get; set; }
        public string Icone { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public List<SidebarItem> SubItens { get; set; } = new();

        public bool TemSubItens => SubItens.Any();
    }
}
