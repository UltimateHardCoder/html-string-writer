namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter.Attributes.Style.Border;
    using HtmlStringWriter.Attributes.Style.Colors;
    using NUnit.Framework;

    public class RgbTests
    {
        private Rgb _rgb;

        [SetUp]
        public void Setup()
        {
            _rgb = new Rgb(0, 0, 0);
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
            Assert.That(result, Is.EqualTo("rgb(0, 0, 0)"));
        }
    }
}