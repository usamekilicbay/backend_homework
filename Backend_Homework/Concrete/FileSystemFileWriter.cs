using Backend_Homework.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Homework.Concrete
{
    internal class FileSystemFileWriter : IFileWriter
    {
        public void WriteFile(string targetFileName, string content)
        {
            try
            {
                using FileStream targetStream = File.Open(targetFileName, FileMode.Create, FileAccess.Write);
                using StreamWriter streamWriter = new(targetStream);
                streamWriter.Write(content);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while writing the file", ex);
            }
        }
    }
}
