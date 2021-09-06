namespace HtmlStringWriter.Table
{
    using System.Collections.Generic;
    using System.Text;
    using Attributes;
    using Interfaces;
    using StaticClasses;

    public class TableHead : AttributeBase, IHtmlElement
    {
        private IList<IChildElement> _children;

        public TableHead(params IHtmlElement[] elements)
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
            sb.Append("<th");
            RenderAttributes(sb);
            sb.Append('>');

            sb.Append(Text ?? string.Empty);
            _children.AddValuesFromList(sb);

            sb.Append("</th>");
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