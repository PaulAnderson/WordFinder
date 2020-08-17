﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder
{
    interface FileService
    {
        Stream OpenFileStream(string fileName);
    }

    class FileServiceImplementation
    {
        public Stream OpenFileStream(string fileName)
        {
            return File.Open(fileName, FileMode.Open);
        }
    }
}
