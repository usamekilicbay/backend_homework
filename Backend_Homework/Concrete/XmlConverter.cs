using Backend_Homework.Abstract;
using Continero.Homework;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Backend_Homework.Concrete
{
    internal class XmlConverter : IFileConverter
    {
        public Document GetDocument(string fileContent)
        {
            try
            {
                XDocument xdoc = XDocument.Parse(fileContent);
                return new Document()
                {
                    Title = xdoc.Root.Element("title").Value,
                    Text = xdoc.Root.Element("text").Value
                };
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while converting file from XML", ex);
            }
        }

        public string GetConvertedFile(Document document)
        {
            try
            {
                using StringWriter stringWriter = new();
                XmlSerializer xmlSerializer = new(typeof(Document));
                xmlSerializer.Serialize(stringWriter, document);
                return stringWriter.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while converting file to XML", ex);
            }
        }
    }
}
