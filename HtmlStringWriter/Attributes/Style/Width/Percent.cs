namespace HtmlStringWriter.Attributes.Style.Colors
{
    using System.Text;
    using Interfaces;

    public class Percent : HtmlElementBase, IHtmlElement
    {
        private readonly double _percent;

        public Percent(double percent)
        {
            _percent = percent;
        }

        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append($"{_percent}%");
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }
    }
}