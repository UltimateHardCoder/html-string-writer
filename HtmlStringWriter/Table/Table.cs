namespace HtmlStringWriter.Table
{
    using System.Collections.Generic;
    using System.Text;
    using Attributes;
    using Interfaces;
    using StaticClasses;

    public class Table : AttributeBase, IChildElement
    {
        private IList<Row> _rows;

        public Table(params IHtmlElement[] elements)
        {
            foreach (var element in elements)
            {
                AddAttribute(element);
                if (element is Row row)
                    AddRow(row);
            }
        }

        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append("<table");
            RenderAttributes(sb);
            sb.Append('>');

            _rows.AddValuesFromList(sb);

            sb.Append("</table>");
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }

        public void AddRow(Row row)
        {
            _rows = _rows.AddElement(row);
        }
    }
}