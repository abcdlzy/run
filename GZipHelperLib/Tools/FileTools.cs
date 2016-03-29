using System;
using System.Collections.Generic;
using System.IO;


namespace GZipHelperLib.Tools
{
    class FileTools
    {
        public static FileInfo[] GetDirAllFiles(string dirPath)
        {
            DirectoryInfo Folder = new DirectoryInfo(dirPath);
            return Folder.GetFiles();
        }
    }
}
