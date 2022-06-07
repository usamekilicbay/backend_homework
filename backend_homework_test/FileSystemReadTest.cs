using Backend_Homework.Abstract;
using Backend_Homework.Concrete;

namespace backend_homework_test
{
    public class FileSystemReadTest
    {
        [Fact]
        public void FileRead_ValidPathShouldWork()
        {
            IFileReader fileReader = new FileSystemFileReader();
            
            string actual = fileReader.ReadFile(Path.Combine(Directory.GetCurrentDirectory(), FileSystemFileReader.SOURCE_FOLDER, "Document1.xml"));

            Assert.True(actual.Length > 0);
        }

        [Fact]
        public void FileRead_NullPathShouldFail()
        {
            Assert.Throws<Exception>(()=> new FileSystemFileReader().ReadFile(""));
        }
        
        [Fact]
        public void FileRead_InvalidDirectoryShouldFail()
        {
            Assert.Throws<Exception>(()=> new FileSystemFileReader().ReadFile("random\\path"));
        }
        
        [Fact]
        public void FileRead_InvalidFileNameShouldFail()
        {
            Assert.Throws<Exception>(()=> new FileSystemFileReader().ReadFile("C:\\Users\\usame\\source\\repos\\backend_homework\\Backend_Homework\\Source Files\\Documen1.xml"));
        }
    }
}