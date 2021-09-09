namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter.Attributes.Style.TextAlign;
    using HtmlStringWriter.StaticClasses;
    using NUnit.Framework;

    public class TextAlignCenterTests
    {
        private TextAlignCenter _textAlignCenter;

        [SetUp]
        public void Setup()
        {
            _textAlignCenter = new TextAlignCenter();
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var result = _textAlignCenter.ToHtmlString();
            AssertTextAlignCenter(result);
        }

        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var sb = new StringBuilder();
            _textAlignCenter.ToHtmlString(sb);

            var result = sb.ToString();
            AssertTextAlignCenter(result);
        }

        private static void AssertTextAlignCenter(string result)
        {
            Assert.That(result, Does.StartWith("text-align: "));
            Assert.That(result, Does.EndWith($"{Constants.Center};"));
        }
    }
}