using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Backend_Homework;
using Backend_Homework.Abstract;
using Backend_Homework.Concrete;

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
            int storageInputMax = Enum.GetNames(typeof(StorageOption)).Length - 1;
            int convertInputMax = Enum.GetNames(typeof(ConvertOption)).Length - 1;

            StorageOption storageReadOption = GetReadStorageOption(storageInputMax);
            ConvertOption convertOption = GetConvertOption(convertInputMax);
            StorageOption storageWriteOption = GetWriteStorageOption(storageInputMax);

            FileManager fileManager = new(GetFileReader(storageReadOption),
                                          GetFileConverter(convertOption),
                                          GetFileWriter(storageWriteOption));
        }

        #region Get Option Input
        private static StorageOption GetWriteStorageOption(int storageInputMax)
        {
            int input;
            bool isInputWithInRange;

            do
            {
                ShowMessage.AskForWriteStorage();
                input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("###################");

                isInputWithInRange = input >= 0 && input <= storageInputMax;

                if (!isInputWithInRange)
                    Console.WriteLine($"Please enter a number within range 0 - {storageInputMax}");

            } while (!isInputWithInRange);
            StorageOption storageWriteOption = (StorageOption)input;
            return storageWriteOption;
        }

        private static ConvertOption GetConvertOption(int convertInputMax)
        {
            int input;
            bool isInputWithInRange;

            do
            {
                ShowMessage.AskForConvertType();
                input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("###################");

                isInputWithInRange = input >= 0 && input <= convertInputMax;

                if (!isInputWithInRange)
                    Console.WriteLine($"Please enter a number within range 0 - {convertInputMax}");

            } while (!isInputWithInRange);
            return (ConvertOption)input;
        }

        private static StorageOption GetReadStorageOption(int storageInputMax)
        {
            int input;
            bool isInputWithInRange;

            do
            {
                ShowMessage.AskForReadStorage();
                input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("###################");

                isInputWithInRange = input >= 0 && input <= storageInputMax;

                if (!isInputWithInRange)
                    Console.WriteLine($"Please enter a number within range 0 - {storageInputMax}");

            } while (!isInputWithInRange);
            return (StorageOption)input;
        }
        #endregion 

        #region Get Injection
        private static IFileConverter GetFileConverter(ConvertOption convertOption)
        {
            return convertOption switch
            {
                ConvertOption.TO_JSON => new JsonConverter(),
                ConvertOption.TO_XML => new XmlConverter(),
                ConvertOption.TO_YAML => new YamlConverter(),
                _ => new JsonConverter(),
            };
        }

        private static IFileReader GetFileReader(StorageOption storageReadOption)
        {
            return storageReadOption switch
            {
                StorageOption.FILE_SYSTEM => new FileSystemFileReader(),
                StorageOption.CLOUD => new CloudStorageFileReader(),
                StorageOption.HTTP => new CloudStorageFileReader(),
                _ => new CloudStorageFileReader(),
            };
        }

        private static IFileWriter GetFileWriter(StorageOption storageWriteOption)
        {
            return storageWriteOption switch
            {
                StorageOption.FILE_SYSTEM => new FileSystemFileWriter(),
                StorageOption.CLOUD => new CloudStorageFileWriter(),
                StorageOption.HTTP => new CloudStorageFileWriter(),
                _ => new CloudStorageFileWriter(),
            };
        }
        #endregion
    }
}