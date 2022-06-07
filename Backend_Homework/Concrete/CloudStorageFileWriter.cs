using Backend_Homework.Abstract;

namespace Backend_Homework.Concrete
{
    internal class CloudStorageFileWriter : IFileWriter
    {
        public string GetTargetFileName()
        {
            throw new NotImplementedException();
        }

        public string GetTargetPath(string targetFileName)
        {
            throw new NotImplementedException();
        }

        public void WriteFile(string targetPath, string content)
        {
            throw new NotImplementedException();
        }
    }
}
