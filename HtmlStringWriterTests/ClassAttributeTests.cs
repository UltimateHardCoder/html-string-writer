namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter.Attributes.Class;
    using HtmlStringWriter.Attributes.Style.VerticalAlign;
    using HtmlStringWriter.StaticClasses;
    using NUnit.Framework;

    public class ClassAttributeTests
    {
        private ClassAttribute _classAttribute;

        [SetUp]
        public void Setup()
        {
            _classAttribute = new ClassAttribute();
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var result = _classAttribute.ToHtmlString();
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var sb = new StringBuilder();
            _classAttribute.ToHtmlString(sb);

            var result = sb.ToString();
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void AddStyle_WhenCalled_AddsClassToClassAttribute()
        {
            _classAttribute.AddClass(new HtmlClass("newClass"));
            var result = _classAttribute.ToHtmlString();

            Assert.That(result, Does.Contain("newClass"));
            Assert.That(result, Does.StartWith($" {Constants.ClassAttribute}"));
        }

        [Test]
        public void AddStyle_WhenCalled_AddsClassToClassAttributeFromString()
        {
            _classAttribute.AddClass("newClass");
            var result = _classAttribute.ToHtmlString();

            Assert.That(result, Does.Contain("newClass"));
            Assert.That(result, Does.StartWith($" {Constants.ClassAttribute}"));
        }

        [Test]
        public void ToHtmlString_WhenCalled_AddsClassToClassAttributeFromConstructor()
        {
            var classAttribute = new ClassAttribute(new HtmlClass("newClass"), new VerticalAlignBottom());
            var result = classAttribute.ToHtmlString();

            Assert.That(result, Does.Contain("newClass"));
            Assert.That(result, Does.Not.Contain("vertical-align"));
            Assert.That(result, Does.Not.Contain(Constants.Bottom));
            Assert.That(result, Does.StartWith($" {Constants.ClassAttribute}"));
        }
    }
}