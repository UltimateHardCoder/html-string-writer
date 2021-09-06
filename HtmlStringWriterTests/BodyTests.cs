namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter;
    using HtmlStringWriter.Attributes.Id;
    using HtmlStringWriter.Div;
    using HtmlStringWriter.Table;
    using NUnit.Framework;

    public class BodyTests
    {
        private Body _body;

        [SetUp]
        public void Setup()
        {
            _body = new Body();
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var result = _body.ToHtmlString();
            AssertResult(result);
        }

        [Test]
        public void ToHtmlStringWithStringBuilder_WhenCalled_ReturnsString()
        {
            var sb = new StringBuilder();
            _body.ToHtmlString(sb);

            var result = sb.ToString();
            AssertResult(result);
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsBodyWithDiv()
        {
            var doc = new Body(new Cell(), new Div(new IdAttribute("123")));
            var result = doc.ToHtmlString();

            Assert.That(result, Does.Contain("<div "));
            Assert.That(result, Does.Contain("</div>"));
            Assert.That(result, Does.Not.Contain("<td>"));
            Assert.That(result, Does.Not.Contain("</td>"));

            AssertResult(result);
        }

        [Test]
        public void AddChild_WhenCalled_ReturnsStringWithDiv()
        {
            _body.AddChild(new Div());
            var result = _body.ToHtmlString();

            Assert.That(result, Does.Contain("<div"));
            Assert.That(result, Does.Contain("</div>"));
            AssertResult(result);
        }

        private static void AssertResult(string result)
        {
            Assert.That(result, Does.Contain("<body>"));
            Assert.That(result, Does.Contain("</body>"));
        }
    }
}