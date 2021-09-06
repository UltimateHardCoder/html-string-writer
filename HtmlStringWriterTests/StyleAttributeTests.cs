namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter.Attributes.Style;
    using HtmlStringWriter.Attributes.Style.TextAlign;
    using HtmlStringWriter.Attributes.Style.VerticalAlign;
    using HtmlStringWriter.StaticClasses;
    using NUnit.Framework;

    public class StyleAttributeTests
    {
        private StyleAttribute _styleAttribute;

        [SetUp]
        public void Setup()
        {
            _styleAttribute = new StyleAttribute();
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var result = _styleAttribute.ToHtmlString();
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var sb = new StringBuilder();
            _styleAttribute.ToHtmlString(sb);

            var result = sb.ToString();
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void AddStyle_WhenCalled_AddsStyleToStyleAttribute()
        {
            _styleAttribute.AddStyle(new VerticalAlignBottom());
            var result = _styleAttribute.ToHtmlString();

            Assert.That(result, Does.Contain("vertical-align"));
            Assert.That(result, Does.Contain(Constants.Bottom));
            Assert.That(result, Does.StartWith($" {Constants.StyleAttribute}"));
        }

        [Test]
        public void ToHtmlString_WhenCalled_AddStyleToAttributeFromConstructor()
        {
            var styleAttribute = new StyleAttribute(new VerticalAlignBottom(), new TextAlignCenter());
            var result = styleAttribute.ToHtmlString();

            Assert.That(result, Does.Contain("vertical-align"));
            Assert.That(result, Does.Contain(Constants.Bottom));
            Assert.That(result, Does.Contain("text-align"));
            Assert.That(result, Does.Contain(Constants.Center));
            Assert.That(result, Does.StartWith($" {Constants.StyleAttribute}"));
        }
    }
}