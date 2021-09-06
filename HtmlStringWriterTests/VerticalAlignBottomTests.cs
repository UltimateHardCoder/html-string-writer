namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter.Attributes.Style.VerticalAlign;
    using HtmlStringWriter.StaticClasses;
    using NUnit.Framework;

    public class VerticalAlignBottomTests
    {
        private VerticalAlignBottom _verticalAlignBottom;

        [SetUp]
        public void Setup()
        {
            _verticalAlignBottom = new VerticalAlignBottom();
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            Assert.That(() => _verticalAlignBottom.ToHtmlString(), Throws.Exception);
        }

        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var sb = new StringBuilder();
            _verticalAlignBottom.ToHtmlString(sb);

            var result = sb.ToString();
            Assert.That(result, Does.StartWith("vertical-align: "));
            Assert.That(result, Does.EndWith($"{Constants.Bottom};"));
        }
    }
}