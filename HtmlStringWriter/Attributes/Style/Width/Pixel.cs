namespace HtmlStringWriter.Attributes.Style.Colors
{
    using System.Text;
    using Interfaces;

    public class Pixel : HtmlElementBase, IHtmlElement
    {
        private readonly double _pixel;

        public Pixel(double pixel)
        {
            _pixel = pixel;
        }

        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append($"{_pixel}px");
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }
    }
}