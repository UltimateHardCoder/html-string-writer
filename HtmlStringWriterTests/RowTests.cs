namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter.Attributes.Class;
    using HtmlStringWriter.Attributes.Style;
    using HtmlStringWriter.Attributes.Style.TextAlign;
    using HtmlStringWriter.Attributes.Style.VerticalAlign;
    using HtmlStringWriter.StaticClasses;
    using HtmlStringWriter.Table;
    using NUnit.Framework;

    public class RowTests
    {
        private Row _row;

        [SetUp]
        public void Setup()
        {
            _row = new Row();
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var result = _row.ToHtmlString();
            AssertResult(result);
        }

        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var sb = new StringBuilder();
            _row.ToHtmlString(sb);

            var result = sb.ToString();
            AssertResult(result);
        }

        [Test]
        public void AddCell_WhenCalled_AddsCellToRow()
        {
            _row.AddCell(new Cell());
            var result = _row.ToHtmlString();

            Assert.That(result, Does.Contain("<td"));
            Assert.That(result, Does.Contain("</td>"));
            AssertResult(result);
        }

        [Test]
        public void AddTableHead_WhenCalled_AddsTableHeadToRow()
        {
            _row.AddTableHead(new TableHead());
            var result = _row.ToHtmlString();

            Assert.That(result, Does.Contain("<th"));
            Assert.That(result, Does.Contain("</th>"));
            AssertResult(result);
        }

        [Test]
        public void ToHtmlString_WhenCalled_AddCellToRow()
        {
            var row = new Row(new Cell());
            var result = row.ToHtmlString();

            Assert.That(result, Does.Contain("<td"));
            Assert.That(result, Does.Contain("</td>"));
            AssertResult(result);
        }

        [Test]
        public void ToHtmlString_WhenCalled_ClassAddedToRow()
        {
            var row = new Row(new ClassAttribute(new HtmlClass("width-5"), new HtmlClass("padding-10"), new HtmlClass("top-15")));
            var result = row.ToHtmlString();

            Assert.That(result, Does.Contain(Constants.ClassAttribute));
            Assert.That(result, Does.Contain("width-5"));
            Assert.That(result, Does.Contain("padding-10"));
            Assert.That(result, Does.Contain("top-15"));
            Assert.That(result, Does.StartWith("<tr"));
            Assert.That(result, Does.EndWith("</tr>"));
        }

        [Test]
        public void ToHtmlString_WhenCalled_StylesAddedToRow()
        {
            var row = new Row(new StyleAttribute(new TextAlignCenter(), new VerticalAlignCenter()));
            var result = row.ToHtmlString();

            Assert.That(result, Does.Contain(Constants.StyleAttribute));
            Assert.That(result, Does.Contain("vertical-align: center"));
            Assert.That(result, Does.Contain("text-align: center"));
            Assert.That(result, Does.StartWith("<tr"));
            Assert.That(result, Does.EndWith("</tr>"));
        }

        [Test]
        public void ToHtmlString_WhenCalled_StylesAndClassAddedToRow()
        {
            var row = new Row(new ClassAttribute(new HtmlClass("width-5"), new HtmlClass("padding-10"), new HtmlClass("top-15")),
                new StyleAttribute(new TextAlignCenter(), new VerticalAlignCenter()));
            var result = row.ToHtmlString();

            Assert.That(result, Does.Contain($" {Constants.StyleAttribute}"));
        }

        private static void AssertResult(string result)
        {
            Assert.That(result, Does.StartWith("<tr>"));
            Assert.That(result, Does.EndWith("</tr>"));
        }
    }
}