using Backend_Homework.Abstract;

namespace Backend_Homework.Concrete
{
    public class FileSystemFileReader : IFileReader
    {
        public const string SOURCE_FOLDER = "Source Files";

        public string ReadFile(string sourcePath)
        {
            try
            {
                using FileStream sourceStream = File.Open(sourcePath, FileMode.Open);
                using StreamReader streamReader = new(sourceStream);
                return streamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while reading the file", ex);
            }
        }

        public string GetSourcePath(string fileExtension)
        {
            bool isFound = false;
            string sourcePath = string.Empty;
            do
            {
                Console.WriteLine("Enter the name of the file you want to upload (without extension)");
                string sourceFileName = Console.ReadLine();
                Console.WriteLine("###################");

                if (string.IsNullOrEmpty(sourceFileName))
                {
                    Console.WriteLine("File not found, try again...");
                    Console.WriteLine("###################");
                    continue;
                }

                sourceFileName += fileExtension;
                sourcePath = Path.Combine(Directory.GetCurrentDirectory(), SOURCE_FOLDER, sourceFileName);

                isFound = File.Exists(sourcePath);

                if (!isFound)
                {
                    Console.WriteLine($"{sourcePath} | File not found, try again...");
                    Console.WriteLine("###################");
                }

            } while (!isFound);
           
            return sourcePath;
        }
    }
}
