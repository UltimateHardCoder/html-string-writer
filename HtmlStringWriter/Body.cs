namespace HtmlStringWriter
{
    using System.Collections.Generic;
    using System.Text;
    using Attributes;
    using Interfaces;
    using StaticClasses;

    public class Body : AttributeBase, IHtmlElement
    {
        private IList<IChildElement> _children;

        public Body(params IHtmlElement[] elements)
        {
            foreach (var element in elements)
                if (element is IChildElement child)
                    AddChild(child);
        }

        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append("<body");
            RenderAttributes(sb);
            sb.Append('>');

            _children.AddValuesFromList(sb);

            sb.Append("</body>");
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }

        public void AddChild(IChildElement child)
        {
            _children = _children.AddElement(child);
        }
    }
}