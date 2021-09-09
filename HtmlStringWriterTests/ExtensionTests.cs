namespace HtmlDocument.UnitTests
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using HtmlStringWriter.Attributes.Class;
    using HtmlStringWriter.StaticClasses;
    using HtmlStringWriter.Table;
    using NUnit.Framework;

    public class ExtensionTests
    {
        [Test]
        [TestCase(null, false)]
        [TestCase(new int[0], false)]
        [TestCase(new[] { 1, 2 }, true)]
        public void HasValue_WhenCalled_ReturnsBool(IList<int> ints, bool expectedResult)
        {
            var result = ints.HasValue();

            Assert.That(result, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void AddValues_WhenCalled_ReturnsStringWithNoSpaceAtTheEnd()
        {
            var htmlClasses = new Collection<HtmlClass> { new("hello"), new("world") };
            var sb = new StringBuilder();
            htmlClasses.AddValues(sb);

            var result = sb.ToString();
            Assert.That(result, Does.StartWith("hello"));
            Assert.That(result, Does.EndWith(" world"));
        }

        [Test]
        public void AddValues_WhenCalled_ReturnsEmptyString()
        {
            var htmlClasses = new Collection<HtmlClass>();
            var sb = new StringBuilder();
            htmlClasses.AddValues(sb);

            var result = sb.ToString();
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void AddValues_WhenCalled_ThrowArgumentNullException()
        {
            Collection<HtmlClass> htmlClasses = null;
            var sb = new StringBuilder();

            Assert.That(() => htmlClasses.AddValues(sb), Throws.ArgumentNullException);
        }

        [Test]
        public void AddValuesFromList_WhenCalled_ReturnsString()
        {
            var cell = new Collection<Cell> { new(), new() };
            var sb = new StringBuilder();
            cell.AddValuesFromList(sb);

            var result = sb.ToString();

            Assert.That(result, Is.EqualTo("<td></td><td></td>"));
        }

        [Test]
        public void AddValuesFromList_AddEmptyArray_ReturnsEmptyString()
        {
            var cell = new Collection<Cell>();
            var sb = new StringBuilder();
            cell.AddValuesFromList(sb);

            var result = sb.ToString();

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void AddValuesFromList_AddNullArray_ReturnsEmptyString()
        {
            Collection<Cell> cell = null;
            var sb = new StringBuilder();
            cell.AddValuesFromList(sb);

            var result = sb.ToString();

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void AddElement_AddNullArray_ReturnsArrayWithItemAddedToIt()
        {
            IList<Cell> cell = null;
            cell = cell.AddElement(new Cell());
            Assert.That(cell.Count, Is.EqualTo(1));

            cell = cell.AddElement(new Cell());
            Assert.That(cell.Count, Is.EqualTo(2));
        }
        
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ToHtmlClass_WhenCalled_ThrowException(string value)
        {
            Assert.That(value.ToHtmlClass, Throws.ArgumentException);
        }

        [Test]
        public void ToHtmlClass_WhenCalled_ChangesToHtmlClass()
        {
            var result = "value".ToHtmlClass();
            Assert.That(result, Is.EqualTo(".value"));
        }
        
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ToHtmlId_WhenCalled_ThrowException(string value)
        {
            Assert.That(value.ToHtmlId, Throws.ArgumentException);
        }

        [Test]
        public void ToHtmlId_WhenCalled_ChangesToHtmlClass()
        {
            var result = "value".ToHtmlId();
            Assert.That(result, Is.EqualTo("#value"));
        }
    }
}