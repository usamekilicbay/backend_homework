namespace Backend_Homework
{
    internal static class ShowMessage
    {
        public static void AskForStorage(OperationType operationType)
        {
            Console.WriteLine($"Please chose storage for file {operationType == OperationType.READ: \"read\" : \"write\"} operation");
            Console.WriteLine($"{(int)StorageOption.FILE_SYSTEM} = {StorageOption.FILE_SYSTEM}");
            Console.WriteLine($"{(int)StorageOption.CLOUD} = {StorageOption.CLOUD}");
            Console.WriteLine($"{(int)StorageOption.HTTP} = {StorageOption.HTTP}");
        }

        public static void AskForConvertType(OperationType operationType)
        {
            string message = operationType switch
            {
                OperationType.READ => "Please chose upload file format",
                OperationType.WRITE => "Please chose format to convert uploaded file",
                _ => "Please chose upload file format",
            };

            Console.WriteLine(message);
            Console.WriteLine($"{(int)ConvertOption.JSON} = {ConvertOption.JSON}");
            Console.WriteLine($"{(int)ConvertOption.XML} = {ConvertOption.XML}");
            Console.WriteLine($"{(int)ConvertOption.YAML} = {ConvertOption.YAML}");
        }
    }
}
