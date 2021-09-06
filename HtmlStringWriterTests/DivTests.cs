namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter.Attributes.Class;
    using HtmlStringWriter.Attributes.Style;
    using HtmlStringWriter.Attributes.Style.TextAlign;
    using HtmlStringWriter.Attributes.Style.VerticalAlign;
    using HtmlStringWriter.Div;
    using HtmlStringWriter.StaticClasses;
    using HtmlStringWriter.Table;
    using NUnit.Framework;

    public class DivTests
    {
        private Div _div;

        [SetUp]
        public void Setup()
        {
            _div = new Div();
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var result = _div.ToHtmlString();
            AssertResult(result);
        }

        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var sb = new StringBuilder();
            _div.ToHtmlString(sb);

            var result = sb.ToString();
            AssertResult(result);
        }

        [Test]
        public void AddChild_WhenCalled_AddsTableToDiv()
        {
            _div.AddChild(new Table());
            var result = _div.ToHtmlString();

            Assert.That(result, Does.Contain("<table"));
            Assert.That(result, Does.Contain("</table>"));
            AssertResult(result);
        }

        [Test]
        public void ToHtmlString_WhenCalled_AddTableToDivFromConstructor()
        {
            var div = new Div(new Table());
            var result = div.ToHtmlString();

            Assert.That(result, Does.Contain("<table"));
            Assert.That(result, Does.Contain("</table>"));
            AssertResult(result);
        }

        [Test]
        public void ToHtmlString_WhenCalled_StylesAndClassAddedToDiv()
        {
            var div = new Div(new ClassAttribute(new HtmlClass("width-5"), new HtmlClass("padding-10"), new HtmlClass("top-15")),
                new StyleAttribute(new TextAlignCenter(), new VerticalAlignCenter()));
            var result = div.ToHtmlString();

            Assert.That(result, Does.Contain("width-5"));
            Assert.That(result, Does.Contain("padding-10"));
            Assert.That(result, Does.Contain("top-15"));
            Assert.That(result, Does.StartWith("<div"));
            Assert.That(result, Does.EndWith("</div>"));
            Assert.That(result, Does.Contain("vertical-align: center"));
            Assert.That(result, Does.Contain("text-align: center"));
            Assert.That(result, Does.Contain($" {Constants.StyleAttribute}"));
            Assert.That(result, Does.Contain($" {Constants.ClassAttribute}"));
        }

        private static void AssertResult(string result)
        {
            Assert.That(result, Does.StartWith("<div>"));
            Assert.That(result, Does.EndWith("</div>"));
        }
    }
}