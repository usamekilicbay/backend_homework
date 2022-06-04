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

            RunConvert();
        }

        const string SOURCE_FILE = "Source Files";
        const string TARGET_FILE = "Target Files";

        private readonly IFileReader _fileReader;
        private readonly IFileConverter _fileConverter;
        private readonly IFileWriter _fileWriter;

        private void RunConvert()
        {
            Console.WriteLine("Enter the name of the file you want to upload (with extension)");
            string sourceFileName = Console.ReadLine();

            Console.WriteLine("Enter a name for the new file (with extension)");
            string targetFileName = Console.ReadLine();

            string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), $"{SOURCE_FILE}\\{sourceFileName}");
            string targetPath = Path.Combine(Directory.GetCurrentDirectory(), $"{TARGET_FILE}\\{targetFileName}");

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

            Console.WriteLine("Operation successful!");
            Console.WriteLine("Press a key to quit...");

            Console.ReadKey();
        }
    }
}
