
using Microsoft.AspNetCore.Html;
using System.IO;
using System.Text.Encodings.Web;

namespace PizzaFlow.Intranet.Portal.Extensions.UI.Form
{
    public class FormField : IHtmlContent
    {
        private IHtmlContent _content;
        private bool _hidden;
        private bool _hiddenInput;

        public FormField(IHtmlContent content)
        {
            _content = content;
        }

        public FormField HideFromView()
        {
            _hidden = true;
            return this;
        }
        public FormField AsHidden()
        {
            _hiddenInput = true;
            return this;
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            if (_hidden)
                return;

            if (_hiddenInput)
            {
                writer.Write(_content.ToString()
                    .Replace("type=\"text\"", "type=\"hidden\"")
                    .Replace("type=\"number\"", "type=\"hidden\"")
                    .Replace("type=\"date\"", "type=\"hidden\""));
                return;
            }

            _content.WriteTo(writer, encoder);
        }
    }

}
