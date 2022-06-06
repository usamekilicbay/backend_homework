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

        private readonly IFileReader _fileReader;
        private readonly IFileConverter _fileConverter;
        private readonly IFileWriter _fileWriter;

        private void RunConvert()
        {
            try
            {
                string fileContext = _fileReader.ReadFile(_fileReader.GetSourcePath());
                string serializedDoc = _fileConverter.GetConvertedFile(fileContext);
                _fileWriter.WriteFile(serializedDoc);
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
