namespace HtmlStringWriter.Attributes.Style.Border
{
    using System.Text;
    using Colors;
    using Interfaces;

    public class BorderRgba : Border, IStyleAttribute
    {
        private readonly Rgba _rgba;

        public BorderRgba(int r, int g, int b, double a)
        {
            _rgba = new Rgba(r, g, b, a);
        }

        public BorderRgba(Rgba rgba)
        {
            _rgba = rgba;
        }
        
        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append(Name);
            _rgba.ToHtmlString(sb);
            sb.Append(';');
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }
    }
}