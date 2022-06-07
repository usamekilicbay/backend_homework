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

            StorageOption storageReadOption = GetStorageOption(storageInputMax, OperationType.READ);
            ConvertOption convertOptionFrom = GetConvertOption(convertInputMax, OperationType.READ);
            ConvertOption convertOptionTo = GetConvertOption(convertInputMax, OperationType.WRITE);
            StorageOption storageWriteOption = GetStorageOption(storageInputMax, OperationType.WRITE);

            FileManager fileManager = new(GetFileReader(storageReadOption),
                                          GetFileConverter(convertOptionFrom),
                                          GetFileConverter(convertOptionTo),
                                          GetFileWriter(storageWriteOption));

            fileManager.RunConvert($".{convertOptionFrom}", $".{convertOptionTo}");
        }

        #region Get Option Input
        private static StorageOption GetStorageOption(int storageInputMax, OperationType operationType)
        {
            int input;
            bool isInputWithInRange;

            do
            {
                ShowMessage.AskForStorage(operationType);
                input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("###################");

                isInputWithInRange = input >= 0 && input <= storageInputMax;

                if (!isInputWithInRange)
                    Console.WriteLine($"Please enter a number within range 0 - {storageInputMax}");

            } while (!isInputWithInRange);
            return (StorageOption)input;
        }

        private static ConvertOption GetConvertOption(int convertInputMax, OperationType operationType)
        {
            int input;
            bool isInputWithInRange;

            do
            {
                ShowMessage.AskForConvertType(operationType);
                input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("###################");

                isInputWithInRange = input >= 0 && input <= convertInputMax;

                if (!isInputWithInRange)
                    Console.WriteLine($"Please enter a number within range 0 - {convertInputMax}");

            } while (!isInputWithInRange);
            return (ConvertOption)input;
        }

        #endregion

        #region Get Injection
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

        private static IFileConverter GetFileConverter(ConvertOption convertOption)
        {
            return convertOption switch
            {
                ConvertOption.JSON => new JsonConverter(),
                ConvertOption.XML => new XmlConverter(),
                ConvertOption.YAML => new YamlConverter(),
                _ => new JsonConverter(),
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