using GZipHelperLib.Struct;
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

        public static void DeleteDirectory(string dirPath)
        {
            if (Directory.GetDirectories(dirPath).Length == 0 && Directory.GetFiles(dirPath).Length == 0)
            {
                Directory.Delete(dirPath);
                return;
            }

            foreach(string var in Directory.GetDirectories(dirPath))
            {
                DeleteDirectory(var);
            }
            foreach(string var in Directory.GetFiles(dirPath))
            {
                File.Delete(var);
            }
            Directory.Delete(dirPath);
        }

        public static List<PacketFile> Combine(List<PacketFile> lpf,string destfile)
        {
            List<PacketFile> rtnlpf = new List<PacketFile>();
            FileStream fs = new FileStream(destfile, FileMode.CreateNew);
            ByteArray ba = new ByteArray(StreamTools.StreamToBytes(fs));
            fs.Close();
            StreamWriter sw = new StreamWriter(destfile);
            sw.Write(PacketFileSerializer(lpf));

            for(int i = 0; i < lpf.Count; i++)
            {
                PacketFile pf = lpf.Find(s => s.SerialNumber == i);
                ByteArray newba = new ByteArray(StreamTools.StreamToBytes(StreamTools.FileToStream(pf.GZipFile)));
                pf.startlocation = ba.getBytes().Length;
                pf.length = newba.getBytes().Length;
                ba += newba;
                rtnlpf.Add(pf);
            }
            FileStream fsa = new FileStream(destfile, FileMode.Append);
            fsa.Write(ba.getBytes(), 0, ba.getBytes().Length);
            fsa.Close();
            return rtnlpf;
        }
        
        public static string PacketFileSerializer(List<PacketFile> lpf)
        {
            string rtnstr = "";
            foreach(var pf in lpf)
            {
                rtnstr += pf.ToString() + "#";
                
            }
            rtnstr += "**";
            return rtnstr;
        }







    }
}
