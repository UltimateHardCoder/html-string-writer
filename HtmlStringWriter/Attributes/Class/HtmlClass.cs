namespace HtmlStringWriter.Attributes.Class
{
    using System;
    using System.Text;
    using Interfaces;

    public class HtmlClass : HtmlElementBase, IHtmlElement
    {
        private readonly string _htmlClass;

        public HtmlClass(string htmlClass)
        {
            if (string.IsNullOrWhiteSpace(htmlClass))
                throw new ArgumentException("Html class name not valid");

            _htmlClass = htmlClass;
        }

        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append(_htmlClass);
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }
    }
}