namespace HtmlStringWriter.Attributes.Style.VerticalAlign
{
    using System;
    using System.Text;
    using Interfaces;
    using StaticClasses;

    public class VerticalAlignBottom : VerticalAlign, IStyleAttribute
    {
        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append($"{Name}{Constants.Bottom};");
        }

        public string ToHtmlString()
        {
            throw new NotImplementedException();
        }
    }
}