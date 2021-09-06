namespace HtmlStringWriter.Attributes.Style.VerticalAlign
{
    using System;
    using System.Text;
    using Interfaces;
    using StaticClasses;

    public class VerticalAlignTop : VerticalAlign, IStyleAttribute
    {
        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append($"{Name}{Constants.Top};");
        }

        public string ToHtmlString()
        {
            throw new NotImplementedException();
        }
    }
}