namespace HtmlStringWriter.Attributes.Style.Border
{
    using System.Text;
    using Colors;
    using Interfaces;

    public class BorderColor : Border, IStyleAttribute
    {
        private readonly Color _color;

        public BorderColor(Color color)
        {
            _color = color;
        }
        
        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append(Name);
            _color.ToHtmlString(sb);
            sb.Append(';');
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }
    }
}