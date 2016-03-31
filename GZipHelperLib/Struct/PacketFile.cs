using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GZipHelperLib.Struct
{
    public class PacketFile
    {
        public FileInfo sourceFileInfo;
        public int SerialNumber;
        public int startlocation;
        public int length;
        public string sourceDir;
        public string GZipFile;


        public PacketFile(FileInfo sourcefileinfo, int serialnumber, string gzipfile,string SourceDir)
        {
            sourceFileInfo = sourcefileinfo;
            SerialNumber = serialnumber;
            GZipFile = gzipfile;
            startlocation = -1;
            length = -1;
            sourceDir = SourceDir;
        }

        public PacketFile(string Serializer)
        {
            byte[] outputb = Convert.FromBase64String(Serializer);
            string orgStr = Encoding.Default.GetString(outputb);
            string[] sps = orgStr.Split('?');
            GZipFile = sps[0];
            SerialNumber = int.Parse(sps[1]);
            startlocation = int.Parse(sps[2]);
            length = int.Parse(sps[3]);
        }

        public override string ToString()
        {
            byte[] bytes = Encoding.Default.GetBytes(sourceFileInfo.FullName.Replace(sourceDir, "") +"?"+SerialNumber + "?" +startlocation + "?" +length );
            string str = Convert.ToBase64String(bytes);
            return str;
        }
    }
}