namespace HtmlStringWriter.Attributes.Style.Font
{
    using System;
    using System.Text;
    using Interfaces;

    public class Width : WidthBase, IStyleAttribute
    {
        private readonly string _value;

        public Width(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(value);

            _value = value;
        }

        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append($"{Name}{_value};");
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }
    }
}