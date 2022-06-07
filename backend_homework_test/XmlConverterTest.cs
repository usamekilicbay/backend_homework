using Backend_Homework.Concrete;

namespace backend_homework_test
{
    public class XmlConverterTest
    {
        [Fact]
        public void XmlConvert_ValidInputShouldWork()
        {
            XmlConverter xmlConverter = new();

            string xmlString = @"<root>
	                                <title>Example Title</title>
	                                <text>Example Text</text>
                                </root>";
            var actual = xmlConverter.GetDocument(xmlString);

            Assert.True(actual.Title != null && actual.Text != null);
        }

        [Fact]
        public void XmlConvert_InvalidInputShouldFail()
        {
            XmlConverter xmlConverter = new();

            string xmlString = @"<root>
	                                <tile>Example Title</tile>
	                                <text>Example Text</text>
                                </root>";
            Assert.Throws<Exception>(() => xmlConverter.GetDocument(xmlString));
        }
    }
}
