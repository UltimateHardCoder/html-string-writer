namespace HtmlStringWriter
{
    using System;
    using System.Text;

    public class HtmlElementBase
    {
        protected static string Render(Action<StringBuilder> toHtmlString)
        {
            var stringBuilder = new StringBuilder();
            toHtmlString(stringBuilder);
            return stringBuilder.ToString();
        }
    }
}