namespace HtmlStringWriter.Table
{
    using System.Collections.Generic;
    using System.Text;
    using Attributes;
    using Interfaces;
    using StaticClasses;

    public class Row : AttributeBase, IHtmlElement
    {
        private IList<Cell> _cells;
        private IList<TableHead> _tableHeads;

        public Row(params IHtmlElement[] elements)
        {
            foreach (var element in elements)
            {
                AddAttribute(element);
                if (element is Cell cell)
                    AddCell(cell);
            }
        }

        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append("<tr");
            RenderAttributes(sb);
            sb.Append('>');

            _cells.AddValuesFromList(sb);
            _tableHeads.AddValuesFromList(sb);

            sb.Append("</tr>");
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }

        public void AddCell(Cell cell)
        {
            _cells = _cells.AddElement(cell);
        }

        public void AddTableHead(TableHead tableHead)
        {
            _tableHeads = _tableHeads.AddElement(tableHead);
        }
    }
}