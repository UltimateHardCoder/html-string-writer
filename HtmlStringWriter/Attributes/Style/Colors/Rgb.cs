namespace HtmlStringWriter.Attributes.Style.Colors
{
    using System.Text;
    using Interfaces;

    public class Rgb : HtmlElementBase, IHtmlElement
    {
        private readonly int _r;
        private readonly int _b;
        private readonly int _g;

        public Rgb(int r, int g, int b)
        {
            _r = r;
            _b = b;
            _g = g;
        }

        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append($"rgb({_r}, {_g}, {_b})");
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }
    }
}