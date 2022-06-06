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
        const string SOURCE_FOLDER = "Source Files";

        public string ReadFile()
        {
            try
            {
                using FileStream sourceStream = File.Open(GetSourcePath(), FileMode.Open);
                using StreamReader streamReader = new(sourceStream);
                return streamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while reading the file", ex);
            }
        }

        public string GetSourcePath()
        {
            bool isFound = false;
            string sourcePath = string.Empty;
            do
            {
                Console.WriteLine("Enter the name of the file you want to upload (with extension)");
                string sourceFileName = Console.ReadLine();
                Console.WriteLine("###################");

                if (string.IsNullOrEmpty(sourceFileName))
                {
                    Console.WriteLine("File not found, try again...");
                    Console.WriteLine("###################");
                    continue;
                }

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
