namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter.Attributes.Style.Font;
    using NUnit.Framework;

    public class FontTests
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void NewlyConstructedFont_WhenCalled_ThrowsException(string value)
        {
            Assert.That(() => new Font(value), Throws.ArgumentException);
        }

        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var sb = new StringBuilder();
            var font = new Font("value");
            font.ToHtmlString(sb);

            var result = sb.ToString();
            AssertFont(result);
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var font = new Font("value");
            var result = font.ToHtmlString();

            AssertFont(result);
        }
        
        private static void AssertFont(string result)
        {
            Assert.That(result, Does.StartWith("font: "));
            Assert.That(result, Does.EndWith("value;"));
        }
    }
}