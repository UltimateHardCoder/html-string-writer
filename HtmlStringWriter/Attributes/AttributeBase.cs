namespace HtmlStringWriter.Attributes
{
    using System.Text;
    using Class;
    using Id;
    using Interfaces;
    using Style;

    public class AttributeBase : HtmlElementBase
    {
        private ClassAttribute _classAttribute;
        private IdAttribute _idAttribute;
        private StyleAttribute _styleAttribute;

        protected void AddAttribute(IHtmlElement element)
        {
            if (element is ClassAttribute classAttribute)
                _classAttribute = classAttribute;
            if (element is StyleAttribute styleAttribute)
                _styleAttribute = styleAttribute;
            if (element is IdAttribute idAttribute)
                _idAttribute = idAttribute;
        }

        protected void RenderAttributes(StringBuilder sb)
        {
            _idAttribute?.ToHtmlString(sb);
            _classAttribute?.ToHtmlString(sb);
            _styleAttribute?.ToHtmlString(sb);
        }
    }
}