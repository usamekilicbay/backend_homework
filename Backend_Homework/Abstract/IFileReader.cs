﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Homework.Abstract
{
    public interface IFileReader
    {
        string ReadFile(string sourcePath);
    }
}
