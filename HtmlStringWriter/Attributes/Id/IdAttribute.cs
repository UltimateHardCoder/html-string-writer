namespace HtmlStringWriter.Attributes.Id
{
    using System;
    using System.Text;
    using Interfaces;

    public class IdAttribute : HtmlElementBase, IHtmlElement
    {
        private readonly string _id;
        private StringBuilder _stringBuilder;

        public IdAttribute(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException(null, nameof(id));

            _id = id;
        }

        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append($" id=\"{_id}\"");
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }
    }
}