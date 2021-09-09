namespace HtmlDocument.UnitTests
{
    using System.Drawing;
    using System.Text;
    using HtmlStringWriter.Attributes.Style.Border;
    using NUnit.Framework;
    using Color = HtmlStringWriter.Attributes.Style.Colors.Color;

    public class BorderColorTests
    {
        private BorderColor _borderColor;

        [SetUp]
        public void Setup()
        {
            _borderColor = new BorderColor(new Color(KnownColor.BlanchedAlmond));
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var result = _borderColor.ToHtmlString();
            AssertBoarderColor(result);
        }
        
        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var sb = new StringBuilder();
            _borderColor.ToHtmlString(sb);

            var result = sb.ToString();
            AssertBoarderColor(result);
        }

        private static void AssertBoarderColor(string result)
        {
            Assert.That(result, Does.StartWith("border: "));
            Assert.That(result, Does.EndWith($"blanchedalmond;"));
        }
    }
}