namespace HtmlStringWriter.Attributes.Style.Border
{
    using System.Text;
    using Interfaces;
    using StaticClasses;

    public class BorderNone : Border, IStyleAttribute
    {
        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append($"{Name}{Constants.None};");
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }
    }
}