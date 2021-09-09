namespace HtmlStringWriter.Attributes.Style.Colors
{
    using System.Drawing;
    using System.Text;
    using Interfaces;

    public class Color : HtmlElementBase, IHtmlElement
    {
        private readonly string _color;

        public Color(KnownColor color)
        {
            _color = $"{color}".ToLower();
        }

        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append(_color);
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }
    }
}