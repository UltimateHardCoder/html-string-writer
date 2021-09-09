namespace HtmlDocument.UnitTests
{
    using System.Drawing;
    using System.Text;
    using NUnit.Framework;
    using Color = HtmlStringWriter.Attributes.Style.Colors.Color;

    public class ColorTests
    {
        private Color _rgb;

        [SetUp]
        public void Setup()
        {
            _rgb = new Color(KnownColor.BlueViolet);
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var result = _rgb.ToHtmlString();
            AssertRgb(result);
        }
        
        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var sb = new StringBuilder();
            _rgb.ToHtmlString(sb);

            var result = sb.ToString();
            AssertRgb(result);
        }

        private static void AssertRgb(string result)
        {
            Assert.That(result, Is.EqualTo("blueviolet"));
        }
    }
}