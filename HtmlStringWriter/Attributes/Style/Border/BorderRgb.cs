namespace HtmlStringWriter.Attributes.Style.Border
{
    using System;
    using System.Text;
    using Interfaces;

    public class BorderRgb : Border, IStyleAttribute
    {
        private readonly int _r;
        private readonly int _b;
        private readonly int _g;

        public BorderRgb(int r, int b, int g)
        {
            _r = r;
            _b = b;
            _g = g;
        }
        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append($"{Name}rgb({_r}, {_g}, {_b});");
        }

        public string ToHtmlString()
        {
            throw new NotImplementedException();
        }
    }
}