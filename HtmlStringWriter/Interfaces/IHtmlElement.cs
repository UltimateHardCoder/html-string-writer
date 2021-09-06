namespace HtmlStringWriter.Interfaces
{
    using System.Text;

    public interface IHtmlElement
    {
        void ToHtmlString(StringBuilder sb);
        string ToHtmlString();
    }
}