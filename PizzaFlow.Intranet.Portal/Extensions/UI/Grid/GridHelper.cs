using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace PizzaFlow.Intranet.Portal.Extensions.UI.Grid
{
    public static class GridHelper
    {
        // ✅ Versão simples
        public static IHtmlContent ShowGridFor<TModel>(
            this IHtmlHelper html,
            IEnumerable<TModel> items,
            params Expression<Func<TModel, object>>[] ignoreColumns)
        {
            return ShowGridFor(html, items, "Editar", null, ignoreColumns);
        }

        // ✅ Versão completa
        public static IHtmlContent ShowGridFor<TModel>(
            this IHtmlHelper html,
            IEnumerable<TModel> items,
            string editAction,
            string editController,
            params Expression<Func<TModel, object>>[] ignoreColumns)
        {
            html.ViewContext.Writer.Write(
                @$"
                    <h1 class=""title"">Clientes Cadastrados</h1>
                    <div class=""form-styled-body"">
                    
                    
                "

            );
            if (items == null || !items.Any())
                return new HtmlString("<p>Nenhum registro encontrado.</p>");

            var properties = typeof(TModel).GetProperties();

            var ignored = ignoreColumns
                .Select(GetPropertyName)
                .ToList();

            var visibleProperties = properties
                .Where(p => !ignored.Contains(p.Name))
                .ToList();

            var sb = new StringBuilder();

            sb.Append("<table class='table table-striped table-bordered'>");

            // HEADER
            sb.Append("<thead><tr>");
            foreach (var prop in visibleProperties)
            {
                sb.Append($"<th>{prop.Name}</th>");
            }
            sb.Append("<th>Ações</th>");
            sb.Append("</tr></thead>");

            // BODY
            sb.Append("<tbody>");

            // 🔥 PEGA LinkGenerator via DI
            var linkGenerator = html.ViewContext.HttpContext
                .RequestServices
                .GetRequiredService<LinkGenerator>();

            var controller = editController ??
                html.ViewContext.RouteData.Values["controller"]?.ToString();

            foreach (var item in items)
            {
                sb.Append("<tr>");

                foreach (var prop in visibleProperties)
                {
                    var value = prop.GetValue(item);
                    sb.Append($"<td>{value}</td>");
                }

                // Busca Id
                var idProp = properties.FirstOrDefault(p => p.Name == "Id");
                var idValue = idProp?.GetValue(item);

                var url = linkGenerator.GetPathByAction(
                    action: editAction,
                    controller: controller,
                    values: new { id = idValue }
                );

                sb.Append($"<td><a class='btn btn-sm btn-primary' href='{url}'>Editar</a></td>");

                sb.Append("</tr>");
            }

            sb.Append("</tbody></table>");

            return new HtmlString(sb.ToString());
        }

        private static string GetPropertyName<TModel>(Expression<Func<TModel, object>> expression)
        {
            if (expression.Body is UnaryExpression unary)
            {
                return ((MemberExpression)unary.Operand).Member.Name;
            }

            return ((MemberExpression)expression.Body).Member.Name;
        }
    }
}
