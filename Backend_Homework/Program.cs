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
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml");


            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json");

            try
            {

                // Potential issue 1: sourceStream not closed. It might cause issues for other reading operations.
                // Potential issue 2: Also it will effect the memory because not disposed as well. I would use "using  statement" to avoid these issues.
                FileStream sourceStream = File.Open(sourceFileName, FileMode.Open);
                var reader = new StreamReader(sourceStream);
                string input = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            // Potential issue 3: input declared inside of try block program can't reach it.
            var xdoc = XDocument.Parse(input);
            // Potential issue 4: title and text nodes might not be exist in xml file.
            var doc = new Document
            {
                Title = xdoc.Root.Element("title").Value,
                Text = xdoc.Root.Element("text").Value
            };

            var serializedDoc = JsonConvert.SerializeObject(doc);
            // Potential issue 5: This part of code should be inside of try-catch blocks for avoiding possible issues while writing/creating the file.
            // Potential issue 6: targetStream and sw should closed and disposed.
            var targetStream = File.Open(targetFileName, FileMode.Create, FileAccess.Write);
            // Potential issue 7: As long as sw is not closed or flushed, writing operation won't be completed. Application might not throw errors but writed file will be empty.
            var sw = new StreamWriter(targetStream);
            sw.Write(serializedDoc);

            // Lastly, this algorithms must be seperated for not violating SOLID principles. I can't look at them anymore, it hurts!
        }
    }
}