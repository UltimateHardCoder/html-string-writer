namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter.Attributes.Style.Font;
    using NUnit.Framework;

    public class WidthTests
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void NewlyConstructedFont_WhenCalled_ThrowsException(string value)
        {
            Assert.That(() => new Width(value), Throws.ArgumentException);
        }

        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var sb = new StringBuilder();
            var width = new Width("value");
            width.ToHtmlString(sb);

            var result = sb.ToString();
            AssertFont(result);
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var width = new Width("value");
            var result = width.ToHtmlString();

            AssertFont(result);
        }
        
        private static void AssertFont(string result)
        {
            Assert.That(result, Does.StartWith("width: "));
            Assert.That(result, Does.EndWith("value;"));
        }
    }
}