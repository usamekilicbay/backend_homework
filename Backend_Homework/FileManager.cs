using Backend_Homework.Abstract;
using Continero.Homework;

namespace Backend_Homework
{
    internal class FileManager
    {
        public FileManager(IFileReader fileReader, IFileConverter fileConverterFrom, IFileConverter fileConverterTo, IFileWriter fileWriter)
        {
            _fileReader = fileReader;
            _fileConverterFrom = fileConverterFrom;
            _fileConverterTo = fileConverterTo;
            _fileWriter = fileWriter;
        }

        private readonly IFileReader _fileReader;
        private readonly IFileConverter _fileConverterFrom;
        private readonly IFileConverter _fileConverterTo;
        private readonly IFileWriter _fileWriter;

        public void RunConvert(string extensionFrom, string extensionTo)
        {
            try
            {
                string fileContext = _fileReader.ReadFile($"{_fileReader.GetSourcePath()}{extensionFrom}");
                Document document = _fileConverterFrom.GetDocument(fileContext);
                string serializedDoc = _fileConverterTo.GetConvertedFile(document);

                _fileWriter.WriteFile($"{_fileWriter.GetTargetPath(_fileWriter.GetTargetFileName())}{extensionTo}", serializedDoc);
                Console.WriteLine("Operation successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
            }

            Console.WriteLine("Press a key to quit...");

            Console.ReadKey();
        }
    }
}
