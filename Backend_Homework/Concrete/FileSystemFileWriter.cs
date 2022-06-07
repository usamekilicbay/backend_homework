using Backend_Homework.Abstract;

namespace Backend_Homework.Concrete
{
    internal class FileSystemFileWriter : IFileWriter
    {
        const string TARGET_FOLDER = "Target Files";

        public void WriteFile(string targetPath, string content)
        {
            try
            {
                using FileStream targetStream = File.Open(targetPath, FileMode.Create, FileAccess.Write);
                using StreamWriter streamWriter = new(targetStream);
                streamWriter.Write(content);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while writing the file", ex);
            }
        }

        public string GetTargetPath(string targetFileName)
        {
            string targetPath = Path.Combine(Directory.GetCurrentDirectory(), TARGET_FOLDER);

            if (!Directory.Exists(targetPath))
                Directory.CreateDirectory(targetPath);

            return Path.Combine(targetPath, targetFileName);
        }

        public string GetTargetFileName()
        {
            string targetFileName;
            do
            {
                Console.WriteLine("Enter a name for the new file (without extension)");
                targetFileName = Console.ReadLine();
            } while (string.IsNullOrEmpty(targetFileName));
            return targetFileName;
        }
    }
}
