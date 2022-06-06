namespace Backend_Homework
{
    internal static class ShowMessage
    {
        public static void AskForWriteStorage()
        {
            Console.WriteLine("Please chose storage to write file");
            Console.WriteLine($"{(int)StorageOption.FILE_SYSTEM} = {StorageOption.FILE_SYSTEM}");
            Console.WriteLine($"{(int)StorageOption.CLOUD} = {StorageOption.CLOUD}");
            Console.WriteLine($"{(int)StorageOption.HTTP} = {StorageOption.HTTP}");
        }

        public static void AskForConvertType()
        {
            Console.WriteLine("Please chose format to convert file");
            Console.WriteLine($"{(int)ConvertOption.TO_JSON} = {ConvertOption.TO_JSON}");
            Console.WriteLine($"{(int)ConvertOption.TO_XML} = {ConvertOption.TO_XML}");
            Console.WriteLine($"{(int)ConvertOption.TO_YAML} = {ConvertOption.TO_YAML}");
        }

        public static void AskForReadStorage()
        {
            Console.WriteLine("Please chose storage to read file from");
            Console.WriteLine($"{(int)StorageOption.FILE_SYSTEM} = {StorageOption.FILE_SYSTEM}");
            Console.WriteLine($"{(int)StorageOption.CLOUD} = {StorageOption.CLOUD}");
            Console.WriteLine($"{(int)StorageOption.HTTP} = {StorageOption.HTTP}");
        }
    }
}
