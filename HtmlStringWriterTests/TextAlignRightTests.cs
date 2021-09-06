namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter.Attributes.Style.TextAlign;
    using HtmlStringWriter.StaticClasses;
    using NUnit.Framework;

    public class TextAlignRightTests
    {
        private TextAlignRight _textAlignRight;

        [SetUp]
        public void Setup()
        {
            _textAlignRight = new TextAlignRight();
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            Assert.That(() => _textAlignRight.ToHtmlString(), Throws.Exception);
        }

        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var sb = new StringBuilder();
            _textAlignRight.ToHtmlString(sb);

            var result = sb.ToString();
            Assert.That(result, Does.StartWith("text-align: "));
            Assert.That(result, Does.EndWith($"{Constants.Right};"));
        }
    }
}