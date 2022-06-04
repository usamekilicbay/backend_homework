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

        public void RunConvert(string sourceFileName)
        {
            // I'm not sure about these lines yet, I'll consider them later.
            //string sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml");

            //string targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json");
            //string sourceFileName = AppDomain.CurrentDomain.BaseDirectory;
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine(path);
            string sourcePath = Path.Combine(path, $"Source Files\\{sourceFileName}");
            Console.WriteLine(sourcePath);

            //string sourceFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Source Files\\Document1.xml");

            string targetPath = Path.Combine(Environment.CurrentDirectory, "\\Docgg.json");
            //string targetFileName = Path.Combine(Environment.CurrentDirectory, );

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
