namespace HtmlStringWriter.Attributes.Style.Font
{
    using System;
    using System.Text;
    using Interfaces;

    public class Font : FontBase, IStyleAttribute
    {
        private readonly string _value;

        public Font(string value)
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