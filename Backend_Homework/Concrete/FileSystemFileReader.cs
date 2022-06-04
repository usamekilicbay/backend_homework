using Backend_Homework.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Homework.Concrete
{
    internal class FileSystemFileReader : IFileReader
    {
        public string ReadFile(string sourceFileName)
        {
            try
            {
                using FileStream sourceStream = File.Open(sourceFileName, FileMode.Open);
                using StreamReader streamReader = new(sourceStream);
                return streamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while reading the file", ex);
            }
        }
    }
}
