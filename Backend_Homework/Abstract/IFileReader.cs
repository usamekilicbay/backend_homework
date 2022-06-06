using System;
namespace Backend_Homework.Abstract
{
    public interface IFileReader
    {
        string ReadFile(string sourcePath);
        string GetSourcePath();
    }
}
