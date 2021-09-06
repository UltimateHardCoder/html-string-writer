namespace HtmlDocument.UnitTests
{
    using System.IO;
    using System.Text;
    using HtmlStringWriter;
    using HtmlStringWriter.Attributes.Style.VerticalAlign;
    using NUnit.Framework;

    public class HeadStyleTests
    {
        private HeadStyle _headStyle;

        [SetUp]
        public void Setup()
        {
            _headStyle = new HeadStyle();
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var result = _headStyle.ToHtmlString();
            AssertResult(result);
        }

        [Test]
        public void ToHtmlStringWithStringBuilder_WhenCalled_ReturnsString()
        {
            var sb = new StringBuilder();
            _headStyle.ToHtmlString(sb);

            var result = sb.ToString();
            AssertResult(result);
        }

        [Test]
        public void AddStyle_WhenCalled_AddsStyleAndPrefixToCssStyle()
        {
            _headStyle.AddCssStyle(new CssStyle(new VerticalAlignBottom()) { CssPrefix = "table" });
            var result = _headStyle.ToHtmlString();

            Assert.That(result, Does.Contain("vertical-align"));
            Assert.That(result, Does.Contain(" table"));
            AssertResult(result);
        }

        [Test]
        public void AddStyle_WhenCalled_AddsStyleAndPrefixToCssStyleInConstructor()
        {
            var headStyle = new HeadStyle(new CssStyle(new VerticalAlignBottom()) { CssPrefix = "table" });
            var result = headStyle.ToHtmlString();

            Assert.That(result, Does.Contain("vertical-align"));
            Assert.That(result, Does.Contain(" table"));
            AssertResult(result);
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsHeadStyleWithCSSFileInText()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "styles.css");
            var file = File.CreateText(filePath);
            file.WriteLine("table { align: center; }");
            file.Close();
            file.Dispose();

            var doc = new HeadStyle(filePath);
            var result = doc.ToHtmlString();

            AssertResult(result);
            File.Delete(filePath);
        }

        private static void AssertResult(string result)
        {
            Assert.That(result, Does.Contain("<style>"));
            Assert.That(result, Does.Contain("</style>"));
        }
    }
}