namespace HtmlStringWriter.Attributes.Style
{
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    using StaticClasses;

    public class StyleAttribute : HtmlElementBase, IHtmlElement
    {
        private IList<IStyleAttribute> _styles;

        public StyleAttribute(params IStyleAttribute[] elements)
        {
            foreach (var element in elements)
                if (element is IStyleAttribute styleAttribute)
                    AddStyle(styleAttribute);
        }

        public void ToHtmlString(StringBuilder sb)
        {
            if (!_styles.HasValue()) return;

            sb.Append(' ');
            sb.Append(Constants.StyleAttribute);
            _styles.AddValues(sb);
            sb.Append('"');
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }

        public void AddStyle(IStyleAttribute styleAttribute)
        {
            _styles = _styles.AddElement(styleAttribute);
        }
    }
}