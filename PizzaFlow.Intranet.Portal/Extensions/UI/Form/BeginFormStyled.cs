using Microsoft.AspNetCore.Mvc.Rendering;

namespace PizzaFlow.Intranet.Portal.Extensions.UI.Form
{
    public static class FormStyledHelper
    {
        public static IDisposable BeginFormStyled(
            this IHtmlHelper html,
            string title,
            string action,
            string controller,
            FormMethod method = FormMethod.Post,
            string cssClass = "form-styled")
        {
            var form = new TagBuilder("form");
            form.Attributes.Add("method", method.ToString().ToLower());
            form.Attributes.Add("action", $"/{controller}/{action}");
            form.AddCssClass(cssClass);

            html.ViewContext.Writer.Write(form.RenderStartTag());

            // container visual
            html.ViewContext.Writer.Write(
                @$"
                    <h1 class=""title"">{title}</h1>
                    <div class=""form-styled-body"">
                    
                    
                "

            );

            return new FormStyledDisposable(html);
        }

        private class FormStyledDisposable : IDisposable
        {
            private readonly IHtmlHelper _html;

            public FormStyledDisposable(IHtmlHelper html)
            {
                _html = html;
            }

            public void Dispose()
            {
                _html.ViewContext.Writer.Write(@"

                    </div>

                    <div style=""margin-top:20px;display:block;position:relative;right:0;"">
                        <button type=""button"">Cancelar</button>
                        <button type=""submit"">Confirmar</button>
                    </div>

                </form>
                    
                ");
            }
        }
    }
}
