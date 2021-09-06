namespace HtmlStringWriter.Attributes.Style.TextAlign
{
    using System;
    using System.Text;
    using Interfaces;
    using StaticClasses;

    public class TextAlignLeft : TextAlign, IStyleAttribute
    {
        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append($"{Name}{Constants.Left};");
        }

        public string ToHtmlString()
        {
            throw new NotImplementedException();
        }
    }
}