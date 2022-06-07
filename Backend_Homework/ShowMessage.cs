namespace Backend_Homework
{
    internal static class ShowMessage
    {
        public static void AskForStorage(string operation)
        {
            Console.WriteLine($"Please chose storage for file {operation} operation");
            Console.WriteLine($"{(int)StorageOption.FILE_SYSTEM} = {StorageOption.FILE_SYSTEM}");
            Console.WriteLine($"{(int)StorageOption.CLOUD} = {StorageOption.CLOUD}");
            Console.WriteLine($"{(int)StorageOption.HTTP} = {StorageOption.HTTP}");
        }

        public static void AskForConvertType()
        {
            Console.WriteLine("Please chose format to convert file");
            Console.WriteLine($"{(int)ConvertOption.JSON} = {ConvertOption.JSON}");
            Console.WriteLine($"{(int)ConvertOption.XML} = {ConvertOption.XML}");
            Console.WriteLine($"{(int)ConvertOption.YAML} = {ConvertOption.YAML}");
        }
    }
}
