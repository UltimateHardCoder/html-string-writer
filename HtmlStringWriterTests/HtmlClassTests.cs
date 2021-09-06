namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter.Attributes.Class;
    using NUnit.Framework;

    public class HtmlClassTests
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ToHtmlString_WhenCalled_ReturnsString(string @class)
        {
            Assert.That(() => new HtmlClass(@class), Throws.ArgumentException);
        }

        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var _idAttribute = new HtmlClass("hello world");
            var sb = new StringBuilder();
            _idAttribute.ToHtmlString(sb);

            var result = sb.ToString();
            Assert.That(result, Is.EqualTo("hello world"));
        }
    }
}