namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter.Attributes.Style.Border;
    using HtmlStringWriter.Attributes.Style.Colors;
    using NUnit.Framework;

    public class BorderRgbaTests
    {
        private BorderRgba _borderRgba;

        [SetUp]
        public void Setup()
        {
            _borderRgba = new BorderRgba(0, 0, 0, .5);
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var result = _borderRgba.ToHtmlString();
            AssertBoarderNone(result);
        }
        
        [Test]
        public void ToHtmlString_WhenRbgObjectAddedToConstructor_ReturnsString()
        {
            var borderRgba = new BorderRgba(new Rgba(0, 0, 0, .5));
            var result = borderRgba.ToHtmlString();
            AssertBoarderNone(result);
        }
        
        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var sb = new StringBuilder();
            _borderRgba.ToHtmlString(sb);

            var result = sb.ToString();
            AssertBoarderNone(result);
        }

        private static void AssertBoarderNone(string result)
        {
            Assert.That(result, Does.StartWith("border: "));
            Assert.That(result, Does.EndWith($"rgba(0, 0, 0, 0.5);"));
        }
    }
}