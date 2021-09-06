namespace HtmlStringWriter
{
    using System.Text;
    using Interfaces;

    public class HtmlDocument : HtmlElementBase, IHtmlElement
    {
        public HtmlDocument()
        {
        }

        public HtmlDocument(params IHtmlElement[] elements)
        {
            foreach (var element in elements)
            {
                if (element is Head head)
                    Head = head;
                if (element is Body body)
                    Body = body;
            }
        }

        private Head Head { get; set; }
        private Body Body { get; set; }

        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append("<!DOCTYPE html>");
            sb.Append("<html>");

            Head?.ToHtmlString(sb);
            Body?.ToHtmlString(sb);

            sb.Append("</html>");
        }

        public string ToHtmlString()
        {
            return Render(ToHtmlString);
        }

        public void AddHead(Head head)
        {
            Head = head;
        }

        public void AddBody(Body body)
        {
            Body = body;
        }
    }
}