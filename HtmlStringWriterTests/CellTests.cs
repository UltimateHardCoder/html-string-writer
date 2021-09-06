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

    public class CellTests
    {
        private Cell _cell;

        [SetUp]
        public void Setup()
        {
            _cell = new Cell();
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var result = _cell.ToHtmlString();
            AssertResult(result);
        }

        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var sb = new StringBuilder();
            _cell.ToHtmlString(sb);

            var result = sb.ToString();
            AssertResult(result);
        }

        [Test]
        public void AddChild_WhenCalled_AddsDivToCell()
        {
            _cell.AddChild(new Div());
            var result = _cell.ToHtmlString();

            Assert.That(result, Does.Contain("<div"));
            Assert.That(result, Does.Contain("</div>"));
            AssertResult(result);
        }

        [Test]
        public void ToHtmlString_WhenCalled_AddDivToCellFromConstructor()
        {
            var cell = new Cell(new Div()) { Text = "hello world" };
            var result = cell.ToHtmlString();

            Assert.That(result, Does.Contain("<div"));
            Assert.That(result, Does.Contain("</div>"));
            Assert.That(result, Does.Contain("hello world"));
            AssertResult(result);
        }

        [Test]
        public void ToHtmlString_WhenCalled_StylesAndClassAddedToCell()
        {
            var cell = new Cell(new ClassAttribute(new HtmlClass("width-5"), new HtmlClass("padding-10"), new HtmlClass("top-15")),
                new StyleAttribute(new TextAlignCenter(), new VerticalAlignCenter()));
            var result = cell.ToHtmlString();

            Assert.That(result, Does.Contain("width-5"));
            Assert.That(result, Does.Contain("padding-10"));
            Assert.That(result, Does.Contain("top-15"));
            Assert.That(result, Does.StartWith("<td"));
            Assert.That(result, Does.EndWith("</td>"));
            Assert.That(result, Does.Contain("vertical-align: center"));
            Assert.That(result, Does.Contain("text-align: center"));
            Assert.That(result, Does.Contain($" {Constants.StyleAttribute}"));
            Assert.That(result, Does.Contain($" {Constants.ClassAttribute}"));
        }

        private static void AssertResult(string result)
        {
            Assert.That(result, Does.StartWith("<td>"));
            Assert.That(result, Does.EndWith("</td>"));
        }
    }
}