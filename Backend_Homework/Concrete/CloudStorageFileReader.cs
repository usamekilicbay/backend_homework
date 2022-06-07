using Backend_Homework.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Homework.Concrete
{
    internal class CloudStorageFileReader : IFileReader
    {
        public string GetSourcePath()
        {
            throw new NotImplementedException();
        }

        public string GetSourcePath(string fileExtension)
        {
            throw new NotImplementedException();
        }

        public string ReadFile(string sourcePath)
        {
            throw new NotImplementedException();
        }
    }
}
