namespace HtmlStringWriter.Attributes.Style.TextAlign
{
    using System;
    using System.Text;
    using Interfaces;
    using StaticClasses;

    public class TextAlignCenter : TextAlign, IStyleAttribute
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