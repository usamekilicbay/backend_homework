using Backend_Homework.Abstract;

namespace Backend_Homework
{
    internal class FileManager
    {
        public FileManager(IFileReader fileReader, IFileConverter fileConverter, IFileWriter fileWriter)
        {
            _fileReader = fileReader;
            _fileConverter = fileConverter;
            _fileWriter = fileWriter;
        }

        private readonly IFileReader _fileReader;
        private readonly IFileConverter _fileConverter;
        private readonly IFileWriter _fileWriter;

        public void RunConvert()
        {
            string sourceFileName = Console.ReadLine();
            string path = Directory.GetCurrentDirectory();
            string sourcePath = Path.Combine(path, $"Source Files\\{sourceFileName}");
            string targetPath = Path.Combine(Environment.CurrentDirectory, "\\Docgg.json");

            try
            {
                string fileContext = _fileReader.ReadFile(sourcePath);
                string serializedDoc = _fileConverter.GetConvertedFile(fileContext);
                _fileWriter.WriteFile(targetPath, serializedDoc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
            }

            Console.WriteLine("Press a key to quit");

            Console.ReadKey();
        }
    }
}
