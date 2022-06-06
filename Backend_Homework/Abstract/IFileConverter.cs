using Continero.Homework;

namespace Backend_Homework.Abstract
{
    public interface IFileConverter
    {
        string GetConvertedFile(Document document);
        Document GetDocument(string fileContent);
    }
}
