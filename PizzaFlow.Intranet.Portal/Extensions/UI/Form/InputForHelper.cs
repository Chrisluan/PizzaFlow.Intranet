using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Linq.Expressions;

namespace PizzaFlow.Intranet.Portal.Extensions.UI.Form
{
    public static class InputForHelper
    {
        public static IHtmlContent InputFor<TModel, TValue>(
            this IHtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression)
        {
          
            var provider = new ModelExpressionProvider(html.MetadataProvider);

            var modelExpression = provider.CreateModelExpression(
                html.ViewData,
                expression
            );

            var fieldName = modelExpression.Name;
            var metadata = modelExpression.Metadata;
            var displayName = metadata.DisplayName ?? metadata.PropertyName ?? fieldName;

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

            var isDateTime = underlyingType == typeof(DateTime);


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


                input = html.TextBoxFor(expression, new
                {

                    type = type,
                    @class = hasError ? "form-control is-invalid" : "form-control"
                });
         

            wrapper.InnerHtml.AppendHtml(label);
            wrapper.InnerHtml.AppendHtml(input);

            if (hasError)
            {
                var error = new TagBuilder("span");
                error.AddCssClass("text-danger");
                error.InnerHtml.Append($"O valor não é válido{entry.Errors[0].ErrorMessage}");

                wrapper.InnerHtml.AppendHtml(error);
            }

            return wrapper;
        }
    }
}
