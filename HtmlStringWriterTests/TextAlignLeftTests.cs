namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter.Attributes.Style.TextAlign;
    using HtmlStringWriter.StaticClasses;
    using NUnit.Framework;

    public class TextAlignLeftTests
    {
        private TextAlignLeft _textAlignLeft;

        [SetUp]
        public void Setup()
        {
            _textAlignLeft = new TextAlignLeft();
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var result = _textAlignLeft.ToHtmlString();
            AssertTextAlignLeft(result);
        }
        
        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var sb = new StringBuilder();
            _textAlignLeft.ToHtmlString(sb);

            var result = sb.ToString();
            AssertTextAlignLeft(result);
        }

        private static void AssertTextAlignLeft(string result)
        {
            Assert.That(result, Does.StartWith("text-align: "));
            Assert.That(result, Does.EndWith($"{Constants.Left};"));
        }
    }
}