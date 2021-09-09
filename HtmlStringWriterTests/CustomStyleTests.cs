namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter.Attributes.Style;
    using NUnit.Framework;

    public class CustomStyleTests
    {
        [Test]
        [TestCase(null, "s")]
        [TestCase("", "s")]
        [TestCase(" ", "s")]
        [TestCase("s", null)]
        [TestCase("s", "")]
        [TestCase("s", " ")]
        public void NewlyConstructedCustomStyle_WhenCalled_ThrowsException(string key, string value)
        {
            Assert.That(() => new CustomStyle(key, value), Throws.ArgumentException);
        }

        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var sb = new StringBuilder();
            var customStyle = new CustomStyle("key", "value");
            customStyle.ToHtmlString(sb);

            var result = sb.ToString();
            AssertFont(result);
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var customStyle = new CustomStyle("key", "value");
            var result = customStyle.ToHtmlString();

            AssertFont(result);
        }

        private static void AssertFont(string result)
        {
            Assert.That(result, Does.StartWith("key: "));
            Assert.That(result, Does.EndWith("value;"));
        }
    }
}