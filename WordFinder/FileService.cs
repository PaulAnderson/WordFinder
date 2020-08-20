using System;
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
        Stream CreateFileStream(string fileName);
    }

    class FileServiceImplementation : FileService
    {
        public Stream OpenFileStream(string fileName)
        {
            return File.Open(fileName, FileMode.Open);
        }
        public Stream CreateFileStream(string fileName)
        {
            return File.Open(fileName, FileMode.Create);
        }
    }
}
