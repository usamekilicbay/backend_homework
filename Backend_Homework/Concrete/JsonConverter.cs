using Backend_Homework.Abstract;
using Continero.Homework;
using Newtonsoft.Json;

namespace Backend_Homework.Concrete
{
    internal class JsonConverter : IFileConverter
    {
        public string GetConvertedFile(Document document)
        {
            try
            {
                return JsonConvert.SerializeObject(document);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while converting the file", ex);
            }
        }

        public Document GetDocument(string fileContent)
        {
            try
            {
                return JsonConvert.DeserializeObject<Document>(fileContent);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while desealization from JSON", ex.Message);
            }
        }
    }
}
