namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter.Attributes.Style.VerticalAlign;
    using HtmlStringWriter.StaticClasses;
    using NUnit.Framework;

    public class VerticalAlignCenterTests
    {
        private VerticalAlignCenter _verticalAlignCenter;

        [SetUp]
        public void Setup()
        {
            _verticalAlignCenter = new VerticalAlignCenter();
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var result = _verticalAlignCenter.ToHtmlString();
            AssertVerticalAlignCenter(result);
        }
        
        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var sb = new StringBuilder();
            _verticalAlignCenter.ToHtmlString(sb);

            var result = sb.ToString();
            AssertVerticalAlignCenter(result);
        }

        private static void AssertVerticalAlignCenter(string result)
        {
            Assert.That(result, Does.StartWith("vertical-align: "));
            Assert.That(result, Does.EndWith($"{Constants.Center};"));
        }
    }
}