namespace HtmlDocument.UnitTests
{
    using System.Text;
    using HtmlStringWriter.Attributes.Style.Border;
    using HtmlStringWriter.StaticClasses;
    using NUnit.Framework;

    public class BorderNoneTests
    {
        private BorderNone _borderNone;

        [SetUp]
        public void Setup()
        {
            _borderNone = new BorderNone();
        }

        [Test]
        public void ToHtmlString_WhenCalled_ReturnsString()
        {
            var result = _borderNone.ToHtmlString();
            AssertBoarderNone(result);
        }
        
        [Test]
        public void ToHtmlString_WhenCalled_FillsStringBuilders()
        {
            var sb = new StringBuilder();
            _borderNone.ToHtmlString(sb);

            var result = sb.ToString();
            AssertBoarderNone(result);
        }

        private static void AssertBoarderNone(string result)
        {
            Assert.That(result, Does.StartWith("border: "));
            Assert.That(result, Does.EndWith($"{Constants.None};"));
        }
    }
}