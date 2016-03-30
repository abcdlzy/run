using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GZipHelperLib.Struct
{
    class PacketFile
    {
        public FileInfo sourceFileInfo;
        public int SerialNumber;
        public int startlocation;
        public int length;
        public string AESEncryptFile;
        public string GZipFile;

        public PacketFile(FileInfo sourcefileinfo,int serialnumber,string encryptfile)
        {
            sourceFileInfo = sourcefileinfo;
            SerialNumber = serialnumber;
            AESEncryptFile = encryptfile;
            startlocation = -1;
            length = -1;

        }

        public PacketFile(string Serializer)
        {
            byte[] outputb = Convert.FromBase64String(Serializer);
            string orgStr = Encoding.Default.GetString(outputb);
            string[] sps = orgStr.Split('?');
            FileInfo fi = new FileInfo(sps[0]);
            SerialNumber = int.Parse(sps[1]);
            startlocation = int.Parse(sps[2]);
            length = int.Parse(sps[3]);
            AESEncryptFile = sps[4];
            GZipFile = sps[5];
        }

        public override string ToString()
        {
            byte[] bytes = Encoding.Default.GetBytes(sourceFileInfo.Name+"?"+SerialNumber + "?" +startlocation + "?" +length + "?" +AESEncryptFile + "?" +GZipFile);
            string str = Convert.ToBase64String(bytes);
            return str;
        }
    }
}