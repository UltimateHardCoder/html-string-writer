namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter.Attributes.Class;
    using HtmlStringWriter.Attributes.Id;
    using HtmlStringWriter.Attributes.Style;
    using HtmlStringWriter.Attributes.Style.TextAlign;
    using HtmlStringWriter.Attributes.Style.VerticalAlign;
    using HtmlStringWriter.StaticClasses;
    using HtmlStringWriter.Table;
    using NUnit.Framework;

    public class TableTests
    {
        private Table _table;

        [SetUp]
        public void Setup()
        {
            _table = new Table();
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var result = _table.ToHtmlString();
            AssertResult(result);
        }

        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var sb = new StringBuilder();
            _table.ToHtmlString(sb);

            var result = sb.ToString();
            AssertResult(result);
        }

        [Test]
        public void AddRow_WhenCalled_AddsRowsToTable()
        {
            _table.AddRow(new Row());
            var result = _table.ToHtmlString();

            Assert.That(result, Does.Contain("<tr"));
            Assert.That(result, Does.Contain("</tr>"));
            AssertResult(result);
        }

        [Test]
        public void ToHtmlString_WhenCalled_RowAddedToTable()
        {
            var table = new Table(new Row());
            var result = table.ToHtmlString();

            Assert.That(result, Does.Contain("<tr"));
            Assert.That(result, Does.Contain("</tr>"));
            AssertResult(result);
        }

        [Test]
        public void ToHtmlString_WhenCalled_ClassAddedToTable()
        {
            var table = new Table(new ClassAttribute(new HtmlClass("width-5"), new HtmlClass("padding-10"), new HtmlClass("top-15")));
            var result = table.ToHtmlString();

            Assert.That(result, Does.Contain(Constants.ClassAttribute));
            Assert.That(result, Does.Contain("width-5"));
            Assert.That(result, Does.Contain("padding-10"));
            Assert.That(result, Does.Contain("top-15"));
            Assert.That(result, Does.StartWith("<table"));
            Assert.That(result, Does.EndWith("</table>"));
        }

        [Test]
        public void ToHtmlString_WhenCalled_StylesAddedToTable()
        {
            var table = new Table(new StyleAttribute(new TextAlignCenter(), new VerticalAlignCenter()));
            var result = table.ToHtmlString();

            Assert.That(result, Does.Contain(Constants.StyleAttribute));
            Assert.That(result, Does.Contain("vertical-align: center"));
            Assert.That(result, Does.Contain("text-align: center"));
            Assert.That(result, Does.StartWith("<table"));
            Assert.That(result, Does.EndWith("</table>"));
        }

        [Test]
        public void ToHtmlString_WhenCalled_StylesAndClassAddedToTable()
        {
            var table = new Table(new ClassAttribute(new HtmlClass("width-5"), new HtmlClass("padding-10"), new HtmlClass("top-15")),
                new StyleAttribute(new TextAlignCenter(), new VerticalAlignCenter()));
            var result = table.ToHtmlString();

            Assert.That(result, Does.Contain($" {Constants.StyleAttribute}"));
        }

        [Test]
        public void ToHtmlString_WhenCalled_IdAndClassAddedToTable()
        {
            var table = new Table(new IdAttribute("par 5"), new ClassAttribute(new HtmlClass("width-5"), new HtmlClass("padding-10"), new HtmlClass("top-15")));
            var result = table.ToHtmlString();

            Assert.That(result, Does.Contain(" id=\"par 5\" "));
        }

        private static void AssertResult(string result)
        {
            Assert.That(result, Does.StartWith("<table>"));
            Assert.That(result, Does.EndWith("</table>"));
        }
    }
}