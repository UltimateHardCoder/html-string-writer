namespace HtmlStringWriter.Attributes.Style.Border
{
    using System.Text;
    using Colors;
    using Interfaces;

    public class BorderRgb : Border, IStyleAttribute
    {
        private readonly Rgb _rgb;

        public BorderRgb(int r, int g, int b)
        {
            _rgb = new Rgb(r, g, b);
        }

        public BorderRgb(Rgb rgb)
        {
            _rgb = rgb;
        }
        
        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append(Name);
            _rgb.ToHtmlString(sb);
            sb.Append(';');
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }
    }
}