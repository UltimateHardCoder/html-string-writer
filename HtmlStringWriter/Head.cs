namespace HtmlStringWriter
{
    using System.Text;
    using Interfaces;

    public class Head : HtmlElementBase, IHtmlElement
    {
        public Head(params IHtmlElement[] elements)
        {
            foreach (var element in elements)
                if (element is HeadStyle headStyle)
                    HeadStyle = headStyle;
        }

        private HeadStyle HeadStyle { get; set; }

        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append("<head>");
            HeadStyle?.ToHtmlString(sb);
            sb.Append("</head>");
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }

        public void AddHeadStyle(HeadStyle headStyle)
        {
            HeadStyle = headStyle;
        }
    }
}