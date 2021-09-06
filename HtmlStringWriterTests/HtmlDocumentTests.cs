namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter;
    using NUnit.Framework;

    public class HtmlDocumentTests
    {
        private HtmlDocument _doc;

        [SetUp]
        public void Setup()
        {
            _doc = new HtmlDocument();
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var result = _doc.ToHtmlString();
            AssertResult(result);
        }

        [Test]
        public void ToHtmlStringWithStringBuilder_WhenCalled_ReturnsString()
        {
            var sb = new StringBuilder();
            _doc.ToHtmlString(sb);

            var result = sb.ToString();
            AssertResult(result);
        }

        [Test]
        public void AddHead_WhenCalled_AddsHeadToHtml()
        {
            _doc.AddHead(new Head());
            var result = _doc.ToHtmlString();
            Assert.That(result, Does.Contain("<head>"));
            Assert.That(result, Does.Contain("</head>"));
            AssertResult(result);
        }

        [Test]
        public void AddBody_WhenCalled_AddsBodyToHtml()
        {
            _doc.AddBody(new Body());
            var result = _doc.ToHtmlString();
            Assert.That(result, Does.Contain("<body>"));
            Assert.That(result, Does.Contain("</body>"));
            AssertResult(result);
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsDocWithBodyAndHead()
        {
            var doc = new HtmlDocument(new Body(), new Head());
            var result = doc.ToHtmlString();

            Assert.That(result, Does.Contain("<head>"));
            Assert.That(result, Does.Contain("</head>"));
            Assert.That(result, Does.Contain("<body>"));
            Assert.That(result, Does.Contain("</body>"));
            AssertResult(result);
        }

        private static void AssertResult(string result)
        {
            Assert.That(result, Does.StartWith("<!DOCTYPE html><html>"));
            Assert.That(result, Does.EndWith("</html>"));
        }
    }
}