namespace HtmlStringWriter.Attributes.Style.VerticalAlign
{
    using System.Text;
    using Interfaces;
    using StaticClasses;

    public class VerticalAlignCenter : VerticalAlign, IStyleAttribute
    {
        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append($"{Name}{Constants.Center};");
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }
    }
}