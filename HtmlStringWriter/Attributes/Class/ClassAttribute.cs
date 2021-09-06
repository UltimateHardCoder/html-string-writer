namespace HtmlStringWriter.Attributes.Class
{
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    using StaticClasses;

    public class ClassAttribute : HtmlElementBase, IHtmlElement
    {
        private IList<HtmlClass> _classes;

        public ClassAttribute(params IHtmlElement[] elements)
        {
            foreach (var element in elements)
                if (element is HtmlClass htmlClass)
                    AddClass(htmlClass);
        }

        public void ToHtmlString(StringBuilder sb)
        {
            if (!_classes.HasValue()) return;

            sb.Append(' ');
            sb.Append(Constants.ClassAttribute);
            _classes.AddValues(sb);
            sb.Append('"');
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }

        public void AddClass(string htmlClass)
        {
            _classes = _classes.AddElement(new HtmlClass(htmlClass));
        }

        public void AddClass(HtmlClass htmlClass)
        {
            _classes = _classes.AddElement(htmlClass);
        }
    }
}