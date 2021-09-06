namespace HtmlStringWriter.Attributes.Style.Border
{
    using System;
    using System.Text;
    using Interfaces;

    public class BorderRgba : Border, IStyleAttribute
    {
        private readonly int _r;
        private readonly int _b;
        private readonly int _g;
        private readonly int _a;

        public BorderRgba(int r, int b, int g, int a)
        {
            _r = r;
            _b = b;
            _g = g;
            _a = a;
        }
        public void ToHtmlString(StringBuilder sb)
        {
            sb.Append($"{Name}rgb({_r}, {_g}, {_b}, {_a});");
        }

        public string ToHtmlString()
        {
            throw new NotImplementedException();
        }
    }
}