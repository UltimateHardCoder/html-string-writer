namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter;
    using NUnit.Framework;

    public class HeadTests
    {
        private Head _head;

        [SetUp]
        public void Setup()
        {
            _head = new Head();
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var result = _head.ToHtmlString();
            AssertResult(result);
        }

        [Test]
        public void ToHtmlStringWithStringBuilder_WhenCalled_ReturnsString()
        {
            var sb = new StringBuilder();
            _head.ToHtmlString(sb);

            var result = sb.ToString();
            AssertResult(result);
        }

        [Test]
        public void AddHeadStyle_WhenCalled_AddsHeadStyleToHead()
        {
            _head.AddHeadStyle(new HeadStyle());
            var result = _head.ToHtmlString();
            Assert.That(result, Does.Contain("<style>"));
            Assert.That(result, Does.Contain("</style>"));
            AssertResult(result);
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsHeadWithHeadStyle()
        {
            var doc = new Head(new HeadStyle());
            var result = doc.ToHtmlString();

            Assert.That(result, Does.Contain("<style>"));
            Assert.That(result, Does.Contain("</style>"));
            AssertResult(result);
        }

        private static void AssertResult(string result)
        {
            Assert.That(result, Does.Contain("<head>"));
            Assert.That(result, Does.Contain("</head>"));
        }
    }
}