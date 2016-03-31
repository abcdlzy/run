using GZipHelperLib.Struct;
using System;
using System.Collections.Generic;
using System.IO;


namespace GZipHelperLib.Tools
{
    public class FileTools
    {
        public static List<FileInfo> GetDirAllFiles(string dirPath)
        {
            List<FileInfo> rtnlfi = new List<FileInfo>();
            DirectoryInfo Folder = new DirectoryInfo(dirPath);
            foreach (var dir in Folder.GetDirectories())
            {
                List<FileInfo> lfi=GetDirAllFiles(dir.FullName);
                foreach(var fi in lfi)
                {
                    rtnlfi.Add(fi);
                }
            }
            FileInfo[] ffi=Folder.GetFiles();
            for(int i = 0; i < ffi.Length; i++)
            {
                rtnlfi.Add(ffi[i]);
            }
            return rtnlfi;
            
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
            FileStream fs = new FileStream(destfile, FileMode.Create);
            ByteArray ba = new ByteArray(StreamTools.StreamToBytes(fs));
            fs.Close();


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



        public static byte[] ReadFile(string fileName)
        {
            FileStream pFileStream = null;
            byte[] pReadByte = new byte[0];
            try
            {
                pFileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(pFileStream);
                r.BaseStream.Seek(0, SeekOrigin.Begin);    //将文件指针设置到文件开  
                pReadByte = r.ReadBytes((int)r.BaseStream.Length);
                return pReadByte;
            }
            catch
            {
                return pReadByte;
            }
            finally
            {
                if (pFileStream != null)
                    pFileStream.Close();
            }
        }

        public static string ReadFiletoString(string fileName)
        {
            FileStream pFileStream = null;
            byte[] pReadByte = new byte[0];
            try
            {
                pFileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(pFileStream);
                r.BaseStream.Seek(0, SeekOrigin.Begin);    //将文件指针设置到文件开  
                pReadByte = r.ReadBytes((int)r.BaseStream.Length);
                return System.Text.Encoding.Default.GetString(pReadByte);
            }
            catch
            {
                return System.Text.Encoding.Default.GetString(pReadByte);
            }
            finally
            {
                if (pFileStream != null)
                    pFileStream.Close();
            }
        }

        //写byte[]到fileName  

        public static bool writeFile(byte[] pReadByte, string fileName)
        {
            FileStream pFileStream = null;
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                pFileStream = new FileStream(fileName, FileMode.OpenOrCreate);
                pFileStream.Write(pReadByte, 0, pReadByte.Length);
            }
            catch
            {
                return false;
            }
            finally
            {
                if (pFileStream != null)
                    pFileStream.Close();
            }
            return true;
        }


        public static bool writeFile(string writestr, string fileName)
        {

            FileStream pFileStream = null;
            try
            {
                byte[] pReadByte = System.Text.Encoding.Default.GetBytes(writestr);
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                pFileStream = new FileStream(fileName, FileMode.OpenOrCreate);
                pFileStream.Write(pReadByte, 0, pReadByte.Length);
            }
            catch
            {
                return false;
            }
            finally
            {
                if (pFileStream != null)
                    pFileStream.Close();
            }
            return true;
        }



    }
}
