﻿using System;
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

            string fileContext = ReadFile(sourceFileName);

            // Potential issue 3: input declared inside of try block program can't reach it.
            string serializedDoc = GetConvertedFile(targetFileName, fileContext);
            
            WriteFile(targetFileName, serializedDoc);


            // Lastly, this algorithms must be seperated for not violating SOLID principles. I can't look at them anymore, it hurts!
        }

        private static string GetConvertedFile(string targetFileName, string fileContext)
        {
            XDocument xdoc = XDocument.Parse(fileContext);
            // Potential issue 4: title and text nodes might not be exist in xml file.
            Document doc = new()
            {
                Title = xdoc.Root.Element("title").Value,
                Text = xdoc.Root.Element("text").Value
            };

            return  JsonConvert.SerializeObject(doc);
        }

        private static void WriteFile(string targetFileName, string serializedDoc)
        {
            // Potential issue 5: This part of code should be inside of try-catch blocks for avoiding possible issues while writing/creating the file.
            // Potential issue 6: targetStream and sw should closed and disposed.
            using FileStream targetStream = File.Open(targetFileName, FileMode.Create, FileAccess.Write);
            // Potential issue 7: As long as sw is not closed or flushed, writing operation won't be completed. Application might not throw errors but writed file will be empty.
            using StreamWriter streamWriter = new(targetStream);
            streamWriter.Write(serializedDoc);
        }

        // Reads the file and returns content if it's successful. Otherwise throws exception.
        private static string ReadFile(string sourceFileName)
        {
            try
            {
                // Potential issue 1: sourceStream not closed. It might cause issues for other reading operations.
                // Potential issue 2: Also it will effect the memory because not disposed as well. I would use "using  statement" to avoid these issues.
                using FileStream sourceStream = File.Open(sourceFileName, FileMode.Open);
                using StreamReader streamReader = new(sourceStream);
                return streamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}