namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter.Attributes.Style.Border;
    using HtmlStringWriter.Attributes.Style.Colors;
    using NUnit.Framework;

    public class BorderRgbTests
    {
        private BorderRgb _borderRgb;

        [SetUp]
        public void Setup()
        {
            _borderRgb = new BorderRgb(0, 0, 0);
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var result = _borderRgb.ToHtmlString();
            AssertBoarderNone(result);
        }
        
        [Test]
        public void ToHtmlString_WhenRbgObjectAddedToConstructor_ReturnsString()
        {
            var borderRbg = new BorderRgb(new Rgb(0, 0, 0));
            var result = borderRbg.ToHtmlString();
            AssertBoarderNone(result);
        }
        
        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var sb = new StringBuilder();
            _borderRgb.ToHtmlString(sb);

            var result = sb.ToString();
            AssertBoarderNone(result);
        }

        private static void AssertBoarderNone(string result)
        {
            Assert.That(result, Does.StartWith("border: "));
            Assert.That(result, Does.EndWith($"rgb(0, 0, 0);"));
        }
    }
}