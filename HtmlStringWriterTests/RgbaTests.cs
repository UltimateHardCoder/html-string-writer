namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter.Attributes.Style.Colors;
    using NUnit.Framework;

    public class RgbaTests
    {
        private Rgba _rgba;

        [SetUp]
        public void Setup()
        {
            _rgba = new Rgba(0, 0, 0, .5);
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var result = _rgba.ToHtmlString();
            AssertBoarderNone(result);
        }
        
        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var sb = new StringBuilder();
            _rgba.ToHtmlString(sb);

            var result = sb.ToString();
            AssertBoarderNone(result);
        }

        private static void AssertBoarderNone(string result)
        {
            Assert.That(result, Is.EqualTo("rgba(0, 0, 0, 0.5)"));
        }
    }
}