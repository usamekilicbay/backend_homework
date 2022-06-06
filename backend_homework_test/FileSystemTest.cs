using Backend_Homework.Abstract;
using Backend_Homework.Concrete;

namespace backend_homework_test
{
    public class FileSystemTest
    {
        [Fact]
        public void FileRead_ValidPathShouldWork()
        {
            IFileReader fileReader = new FileSystemFileReader();
            
            string actual = fileReader.ReadFile("C:\\Users\\usame\\source\\repos\\backend_homework\\Backend_Homework\\Source Files\\Document1.xml");

            Assert.True(actual.Length > 0);
        }
    }
}