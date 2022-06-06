using Backend_Homework.Abstract;
using Continero.Homework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Backend_Homework.Concrete
{
    internal class JsonConverter : IFileConverter
    {
        public string GetConvertedFile(string fileContext)
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
    }
}
