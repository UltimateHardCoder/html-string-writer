namespace HtmlStringWriter.Attributes.Style.Colors
{
    using System.Text;
    using Interfaces;

    public class Rgba : HtmlElementBase, IHtmlElement
    {
        private readonly int _r;
        private readonly int _b;
        private readonly int _g;
        private readonly double _a;

        public Rgba(int r, int g, int b, double a)
        {
            _r = r;
            _b = b;
            _g = g;
            _a = a;
        }

        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append($"rgba({_r}, {_g}, {_b}, {_a})");
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }
    }
}