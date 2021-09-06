namespace HtmlStringWriter
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Interfaces;
    using StaticClasses;

    public class HeadStyle : HtmlElementBase, IHtmlElement
    {
        private readonly string _cssFilePath;
        private IList<CssStyle> _styles;

        public HeadStyle()
        {
        }

        public HeadStyle(string cssFilePath)
        {
            _cssFilePath = cssFilePath;
        }

        public HeadStyle(params IHtmlElement[] elements)
        {
            foreach (var element in elements)
                if (element is CssStyle cssStyle)
                    AddCssStyle(cssStyle);
        }

        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append("<style>");
            if (!string.IsNullOrEmpty(_cssFilePath)) sb.Append(File.ReadAllText(_cssFilePath));

            _styles?.AddValues(sb);

            sb.Append("</style>");
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }

        public void AddCssStyle(CssStyle cssStyle)
        {
            _styles = _styles.AddElement(cssStyle);
        }
    }
}