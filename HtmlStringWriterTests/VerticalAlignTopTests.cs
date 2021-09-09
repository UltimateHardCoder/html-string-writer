namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter.Attributes.Style.VerticalAlign;
    using HtmlStringWriter.StaticClasses;
    using NUnit.Framework;

    public class VerticalAlignTopTests
    {
        private VerticalAlignTop _verticalAlignTop;

        [SetUp]
        public void Setup()
        {
            _verticalAlignTop = new VerticalAlignTop();
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var result = _verticalAlignTop.ToHtmlString();
            AssertVerticalAlignTop(result);
        }

        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var sb = new StringBuilder();
            _verticalAlignTop.ToHtmlString(sb);

            var result = sb.ToString();
            AssertVerticalAlignTop(result);
        }

        private static void AssertVerticalAlignTop(string result)
        {
            Assert.That(result, Does.StartWith("vertical-align: "));
            Assert.That(result, Does.EndWith($"{Constants.Top};"));
        }
    }
}