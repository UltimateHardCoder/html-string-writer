namespace HtmlStringWriter.Table
{
    using System.Collections.Generic;
    using System.Text;
    using Attributes;
    using Interfaces;
    using StaticClasses;

    public class Cell : AttributeBase, IHtmlElement
    {
        private IList<IChildElement> _children;

        public Cell(params IHtmlElement[] elements)
        {
            foreach (var element in elements)
            {
                AddAttribute(element);
                if (element is IChildElement child)
                    AddChild(child);
            }
        }

        public string Text { get; set; }

        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append("<td");
            RenderAttributes(sb);
            sb.Append('>');

            sb.Append(Text ?? string.Empty);
            _children.AddValuesFromList(sb);

            sb.Append("</td>");
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