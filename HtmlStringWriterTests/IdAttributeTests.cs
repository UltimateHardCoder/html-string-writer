namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter.Attributes.Id;
    using NUnit.Framework;

    public class IdAttributeTests
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ToHtmlString_WhenCalled_ReturnsString(string id)
        {
            Assert.That(() => new IdAttribute(id), Throws.ArgumentException);
        }

        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var _idAttribute = new IdAttribute("hello world");
            var sb = new StringBuilder();
            _idAttribute.ToHtmlString(sb);

            var result = sb.ToString();
            Assert.That(result, Does.StartWith(" id="));
            Assert.That(result, Does.Contain("hello world"));
        }
    }
}