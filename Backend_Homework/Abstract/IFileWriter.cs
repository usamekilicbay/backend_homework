using System;
namespace Backend_Homework.Abstract
{
    public interface IFileWriter
    {
        void WriteFile(string context);
        string GetTargetPath(string targetFileName);
        string GetTargetFileName();
    }
}
