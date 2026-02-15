using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PizzaFlow.Intranet.ViewModels.Attributes;
using System.Linq.Expressions;

namespace PizzaFlow.Intranet.Portal.Extensions.UI.Form
{
    public static class InputForHelper
    {
        public static FormField InputFor<TModel, TValue>
 (
             this IHtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression, string? mask = "")
        {
          
            var provider = new ModelExpressionProvider(html.MetadataProvider);

            var modelExpression = provider.CreateModelExpression(
                html.ViewData,
                expression
            );

            var fieldName = modelExpression.Name;
            var metadata = modelExpression.Metadata;
            var displayName = metadata.DisplayName ?? metadata.PropertyName ?? fieldName;
            var maskAttribute = metadata
                .ContainerType?
                .GetProperty(metadata.PropertyName)?
                .GetCustomAttributes(typeof(MaskAttribute), false)
                .FirstOrDefault() as MaskAttribute;

            var maskValue = maskAttribute?.Pattern;
            var hasError =
                html.ViewData.ModelState.TryGetValue(fieldName, out var entry) &&
                entry.Errors.Count > 0;

            var wrapper = new TagBuilder("div");
            wrapper.AddCssClass("form-group");

            var label = new TagBuilder("label");


            label.Attributes.Add("style", "bottom: 20px");
            label.Attributes.Add("for", fieldName);
            label.InnerHtml.Append(displayName);
            var modelType = metadata.ModelType;

            


            var underlyingType = Nullable.GetUnderlyingType(modelType) ?? modelType;

            IHtmlContent input;
            string type = "";

            switch (underlyingType.Name)
            {
                case "DateTime":
                    type = "date";
                    break;

                case "Int32":
                case "float":
                case "double":
                case "Decimal":
                    type = "number";
                    break;
                default:
                    type = "text";
                    break;
            }

            var attributes = new Dictionary<string, object>
            {

                ["type"] = type,
                ["class"] = hasError ? "form-control is-invalid" : "form-control"
                
            };

            if(maskValue != null) attributes.Add("data-mask", maskValue);

            if (underlyingType == typeof(DateTime))
            {
                input = html.TextBoxFor(
                    expression,
                    "{0:yyyy-MM-dd}",
                    attributes
                );
            }
            else
            {
                input = html.TextBoxFor(expression, attributes);
            }

            wrapper.InnerHtml.AppendHtml(label);
            wrapper.InnerHtml.AppendHtml(input);

            if (hasError)
            {
                var error = new TagBuilder("span");
                error.AddCssClass("text-danger");
                error.InnerHtml.Append($"O valor não é válido");

                wrapper.InnerHtml.AppendHtml(error);
            }

            return new FormField(wrapper);
        }
    }
}
