using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq.Expressions;

namespace PizzaFlow.Intranet.Portal.Extensions.UI.Form
{
    public static class FormHelper
    {
        public static IHtmlContent BeginFormBox(
            this IHtmlHelper html,
            string action,
            string controller,
            object routeValues = null,
            string cssClass = "form-box")
        {
            var form = new TagBuilder("form");
            form.Attributes.Add("method", "post");
            form.Attributes.Add("action", $"/{controller}/{action}");
            form.AddCssClass(cssClass);

            return form;
        }
       
    }

}
