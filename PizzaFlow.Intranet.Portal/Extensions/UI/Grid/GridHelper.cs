using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.ComponentModel;

namespace PizzaFlow.Intranet.Portal.Extensions.UI.Grid
{
    public static class GridHelper
    {
        public static GridBuilder<TModel> ShowGridFor<TModel>(
            this IHtmlHelper html,
            IEnumerable<TModel> items,
            params Expression<Func<TModel, object>>[] ignoreColumns)
        {
            return new GridBuilder<TModel>(html, items, ignoreColumns);
        }
    }

    public class GridBuilder<TModel> : IHtmlContent
    {
        private readonly IHtmlHelper _html;
        private readonly IEnumerable<TModel> _items;
        private readonly List<string> _ignoredColumns;
        private readonly List<GridAction> _actions = new();
        private readonly string _gridId = $"grid_{Guid.NewGuid():N}";

        public GridBuilder(
            IHtmlHelper html,
            IEnumerable<TModel> items,
            params Expression<Func<TModel, object>>[] ignoreColumns)
        {
            _html = html;
            _items = items;

            _ignoredColumns = ignoreColumns?
                .Select(GetPropertyName)
                .ToList() ?? new List<string>();
        }

        public GridBuilder<TModel> AddAction(
            string text,
            string action,
            string controller,
            string cssClass = "btn-primary")
        {
            _actions.Add(new GridAction
            {
                Text = text,
                Action = action,
                Controller = controller,
                CssClass = cssClass
            });

            return this;
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            if (_items == null || !_items.Any())
            {
                writer.Write("<p>Nenhum registro encontrado.</p>");
                return;
            }

            var properties = typeof(TModel)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => !_ignoredColumns.Contains(p.Name))
                .ToList();

            var sb = new StringBuilder();

            var linkGenerator = _html.ViewContext.HttpContext
                .RequestServices
                .GetRequiredService<LinkGenerator>();

            // 🔥 TOOLBAR (AÇÕES ACIMA)
            sb.Append($@"
                <div id='{_gridId}_toolbar' class='mb-3' style='display:none;'>
            ");

            foreach (var action in _actions)
            {
                var baseUrl = linkGenerator.GetPathByAction(
                    action: action.Action,
                    controller: action.Controller);

                sb.Append($@"
                    <button class='btn {action.CssClass} me-2'
                       data-base-url='{baseUrl}'
                       onclick='gridExecuteAction(this, ""{_gridId}"")'>
                        {action.Text}
                    </button>
                ");
            }

            sb.Append("</div>");

            // 🔥 TABELA
            sb.Append($"<table id='{_gridId}' class='table table-striped table-bordered'>");

            sb.Append("<thead><tr>");
            sb.Append("<th></th>");

            foreach (var prop in properties)
            {
                var displayName = prop
                    .GetCustomAttribute<DisplayNameAttribute>()?
                    .DisplayName ?? prop.Name;

                sb.Append($"<th>{displayName}</th>");
            }

            sb.Append("</tr></thead>");
            sb.Append("<tbody>");

            foreach (var item in _items)
            {
                var idProp = typeof(TModel).GetProperty("Id");
                var idValue = idProp?.GetValue(item);

                sb.Append("<tr>");

                sb.Append($@"
                    <td>
                        <input type='checkbox'
                               class='grid-checkbox'
                               value='{idValue}'
                               onchange='gridSelectSingle(this, ""{_gridId}"")' />
                    </td>");

                foreach (var prop in properties)
                {
                    var value = prop.GetValue(item) ?? "";
                    sb.Append($"<td>{value}</td>");
                }

                sb.Append("</tr>");
            }

            sb.Append("</tbody></table>");

            // 🔥 SCRIPT
            sb.Append($@"
            <script>
            function gridSelectSingle(checkbox, gridId) {{

                var grid = document.getElementById(gridId);
                var toolbar = document.getElementById(gridId + '_toolbar');

                grid.querySelectorAll('.grid-checkbox').forEach(cb => {{
                    if (cb !== checkbox) cb.checked = false;
                }});

                grid.querySelectorAll('tr').forEach(r => {{
                    r.classList.remove('table-active');
                }});

                if (checkbox.checked) {{
                    var row = checkbox.closest('tr');
                    row.classList.add('table-active');
                    toolbar.style.display = 'block';
                }}
                else {{
                    toolbar.style.display = 'none';
                }}
            }}

            function gridExecuteAction(button, gridId) {{

                var grid = document.getElementById(gridId);
                var selected = grid.querySelector('.grid-checkbox:checked');

                if (!selected) return;

                var baseUrl = button.getAttribute('data-base-url');
                var finalUrl = baseUrl + '/' + selected.value;

                window.location.href = finalUrl;
            }}
            </script>
            ");

            writer.Write(sb.ToString());
        }

        private string GetPropertyName(Expression<Func<TModel, object>> expression)
        {
            if (expression.Body is UnaryExpression unary)
                return ((MemberExpression)unary.Operand).Member.Name;

            return ((MemberExpression)expression.Body).Member.Name;
        }
    }

    public class GridAction
    {
        public string Text { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string CssClass { get; set; }
    }
}
