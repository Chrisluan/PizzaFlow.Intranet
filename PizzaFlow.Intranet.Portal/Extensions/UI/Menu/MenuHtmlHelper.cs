using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaFlow.Intranet.Portal.Extensions.UI.Menu;
using PizzaFlow.Intranet.Portal.Extensions.UI.Menu.Models;
using System.Reflection.Emit;

public static class MenuHtmlHelper
{
    public static IHtmlContent CriarMenu(
        this IHtmlHelper html,
        Action<MenuBuilder> builderAction)
    {
        var builder = MenuBuilder.Criar();
        builderAction(builder);

        var menu = builder.Build();

        return RenderizarMenu(menu);
    }

    private static IHtmlContent RenderizarMenu(List<SidebarMenu> menus)
    {
        var ul = new TagBuilder("ul");
        ul.AddCssClass("sidebar");

        foreach (var categoria in menus)
        {
            var liCategoria = new TagBuilder("li");
            liCategoria.AddCssClass("sidebar-category");

            var titulo = new TagBuilder("span");
            titulo.InnerHtml.AppendHtml(
                $"<i class='{categoria.Icone}'></i> {categoria.Categoria}"
            );

            liCategoria.InnerHtml.AppendHtml(titulo);

            var ulItens = new TagBuilder("ul");

            foreach (var item in categoria.Itens)
                ulItens.InnerHtml.AppendHtml(RenderizarItem(item));

            liCategoria.InnerHtml.AppendHtml(ulItens);
            ul.InnerHtml.AppendHtml(liCategoria);
        }

        return ul;
    }

    private static TagBuilder RenderizarItem(SidebarItem item)
    {
        var li = new TagBuilder("li");
        li.AddCssClass("menu-item");

        var a = new TagBuilder("a");

        if (!item.TemSubItens)
        {
            a.Attributes["href"] = $"/{item.Controller}/{item.Action}";
        }
        else
        {
            a.Attributes["href"] = "javascript:void(0)";
            a.AddCssClass("submenu-toggle");
            li.AddCssClass("has-submenu");
        }

        a.InnerHtml.AppendHtml(
            $"<div class=''><i class='{item.Icone}'></i> <span> {item.Texto}</span></div>"
        );

        if (item.TemSubItens)
        {
            a.InnerHtml.AppendHtml("<i class='fa fa-chevron-down arrow'></i>");
        }

        li.InnerHtml.AppendHtml(a);

        if (item.TemSubItens)
        {
            var ul = new TagBuilder("ul");
            ul.AddCssClass("submenu");

            foreach (var sub in item.SubItens)
                ul.InnerHtml.AppendHtml(RenderizarItem(sub));

            li.InnerHtml.AppendHtml(ul);
        }

        return li;
    }

}
