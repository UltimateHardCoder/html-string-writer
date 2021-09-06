namespace HtmlDocument.UnitTests
{
    using HtmlStringWriter;
    using HtmlStringWriter.Attributes.Style.TextAlign;
    using HtmlStringWriter.Attributes.Style.VerticalAlign;
    using HtmlStringWriter.StaticClasses;
    using NUnit.Framework;

    public class CssStyleTests
    {
        private CssStyle _cssStyle;

        [SetUp]
        public void Setup()
        {
            _cssStyle = new CssStyle();
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ToHtmlString_WhenNoValidCssPrefix_ThrowsArgumentNullException(string cssPrefix)
        {
            _cssStyle.CssPrefix = cssPrefix;
            _cssStyle.AddStyle(new VerticalAlignBottom());
            Assert.That(() => _cssStyle.ToHtmlString(), Throws.ArgumentException);
        }

        [Test]
        public void ToHtmlString_WhenNoStyles_ThrowsArgumentException()
        {
            Assert.That(() => _cssStyle.ToHtmlString(), Throws.ArgumentException);
        }

        [Test]
        public void AddStyle_WhenCalled_AddsStyleAndPrefixToCssStyle()
        {
            _cssStyle.CssPrefix = "table";
            _cssStyle.AddStyle(new VerticalAlignBottom());
            var result = _cssStyle.ToHtmlString();

            Assert.That(result, Does.Contain("vertical-align"));
            Assert.That(result, Does.Contain(Constants.Bottom));
            Assert.That(result, Does.StartWith(" table"));
        }

        [Test]
        public void ToHtmlString_WhenCalled_AddStyleToAttributeFromConstructor()
        {
            var cssStyle = new CssStyle(new VerticalAlignBottom(), new TextAlignCenter()) { CssPrefix = "pd-5" };
            var result = cssStyle.ToHtmlString();

            Assert.That(result, Does.Contain("vertical-align"));
            Assert.That(result, Does.Contain(Constants.Bottom));
            Assert.That(result, Does.Contain("text-align"));
            Assert.That(result, Does.Contain(Constants.Center));
            Assert.That(result, Does.StartWith(" pd-5"));
        }
    }
}