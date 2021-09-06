namespace HtmlStringWriter.Div
{
    using System.Collections.Generic;
    using System.Text;
    using Attributes;
    using Interfaces;
    using StaticClasses;

    public class Div : AttributeBase, IChildElement
    {
        private IList<IChildElement> _children;

        public Div(params IHtmlElement[] elements)
        {
            foreach (var element in elements)
            {
                AddAttribute(element);
                if (element is IChildElement childElement)
                    AddChild(childElement);
            }
        }

        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append("<div");
            RenderAttributes(sb);
            sb.Append('>');

            _children.AddValuesFromList(sb);

            sb.Append("</div>");
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }

        public void AddChild(IChildElement childElement)
        {
            _children = _children.AddElement(childElement);
        }
    }
}