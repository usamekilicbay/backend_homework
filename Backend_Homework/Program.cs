using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;
namespace Continero.Homework
{
    public class Document
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // I'm not sure about these lines yet, I'll consider them later.
            string sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml");


            string targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json");

            try
            {
                string fileContext = ReadFile(sourceFileName);
                string serializedDoc = GetConvertedFile(fileContext);
                WriteFile(targetFileName, serializedDoc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
            }

            Console.ReadKey();
        }

        private static string GetConvertedFile(string fileContext)
        {
            try
            {
                XDocument xdoc = XDocument.Parse(fileContext);
                Document doc = new()
                {
                    Title = xdoc.Root.Element("title").Value,
                    Text = xdoc.Root.Element("text").Value
                };

                return JsonConvert.SerializeObject(doc);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while converting the file", ex);
            }
        }

        private static void WriteFile(string targetFileName, string serializedDoc)
        {
            try
            {
                using FileStream targetStream = File.Open(targetFileName, FileMode.Create, FileAccess.Write);
                using StreamWriter streamWriter = new(targetStream);
                streamWriter.Write(serializedDoc);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while writing the file", ex);
            }
        }

        // Reads the file and returns content if it's successful. Otherwise throws exception.
        private static string ReadFile(string sourceFileName)
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