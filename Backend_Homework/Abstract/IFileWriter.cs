using System;
namespace Backend_Homework.Abstract
{
    public interface IFileWriter
    {
        void WriteFile(string targetPath, string content);
        string GetTargetPath(string targetFileName);
        string GetTargetFileName();
    }
}
