namespace HtmlStringWriter.Attributes.Style.TextAlign
{
    using System;
    using System.Text;
    using Interfaces;
    using StaticClasses;

    public class TextAlignRight : TextAlign, IStyleAttribute
    {
        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append($"{Name}{Constants.Right};");
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }
    }
}