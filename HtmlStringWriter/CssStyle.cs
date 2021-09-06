namespace HtmlStringWriter
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    using StaticClasses;

    public class CssStyle : HtmlElementBase, IHtmlElement
    {
        private IList<IStyleAttribute> _styles;

        public CssStyle(params IStyleAttribute[] elements)
        {
            foreach (var element in elements)
                if (element is IStyleAttribute styleAttribute)
                    AddStyle(styleAttribute);
        }

        public string CssPrefix { get; set; }

        public void ToHtmlString(StringBuilder sb)
        {
            if (!_styles.HasValue())
                throw new ArgumentException("A css object must have styles");

            if (string.IsNullOrWhiteSpace(CssPrefix))
                throw new ArgumentException("A css object must have a prefix. ei table .pd-5 #btn1 ect.");

            sb.Append($" {CssPrefix} ");
            sb.Append('{');
            _styles.AddValues(sb);
            sb.Append('}');
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