namespace HtmlStringWriter.Attributes.Style
{
    using System;
    using System.Text;
    using Interfaces;

    public class CustomStyle : HtmlElementBase, IStyleAttribute
    {
        private readonly string _key;
        private readonly string _value;

        public CustomStyle(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException(key);

            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(value);

            _key = key;
            _value = value;
        }

        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append($"{_key}: {_value};");
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }
    }
}