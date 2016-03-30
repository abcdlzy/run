using GZipHelperLib.Struct;
using GZipHelperLib.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace GZipHelperLib
{
    class GZipHelper
    {
        public static void Compress(string path,string password,string destFile)
        {

            FileInfo[] fi = Tools.FileTools.GetDirAllFiles(path);
            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            DirectoryInfo info = new DirectoryInfo(temp);
            if (Directory.Exists(temp + "/gzipcompress/"))
            {
                FileTools.DeleteDirectory(temp + "/gzipcompress/");
            }
            Directory.CreateDirectory(temp + "/gzipcompress/");
            List<PacketFile> lpf = new List<PacketFile>();
            if (fi.Length > 0)
            {
                for(int i = 0; i < fi.Length; i++)
                {
                    //encrypt files
                    AESTools.encryption(MD5Tools.MD5Encrypt(password), fi[i].FullName, temp + "/gzipcompress/" + fi[i].Name + ".ENC");
                    lpf.Add(new PacketFile(fi[i], i, temp + "/gzipcompress/" + fi[i].Name + ".ENC"));

                }

                //compress files
                foreach(var enc in lpf)
                {
                   CompressData(StreamTools.StreamToBytes(StreamTools.FileToStream(enc.AESEncryptFile)), temp + "/gzipcompress/" + enc.SerialNumber + ".gzip");
                    enc.GZipFile = temp + "/gzipcompress/" + enc.SerialNumber + ".gzip";
                }


                //packet files to file
                
                lpf = FileTools.Combine(lpf, destFile);
                //touch struct file


            }
        }

        public static void Decompress()
        {

        }




        /// <summary>  
        /// 将指定的文件解压,返回解压后的数据  
        /// </summary>  
        /// <param name="srcFile">指定的源文件</param>  
        /// <returns>解压后得到的数据</returns>  
        public static byte[] DecompressData(string srcFile)
        {
            if (false == File.Exists(srcFile))
                throw new FileNotFoundException(String.Format("找不到指定的文件{0}", srcFile));
            FileStream sourceStream = null;
            GZipStream decompressedStream = null;
            byte[] quartetBuffer = null;
            try
            {
                sourceStream = new FileStream(srcFile, FileMode.Open, FileAccess.Read, FileShare.Read);

                decompressedStream = new GZipStream(sourceStream, CompressionMode.Decompress, true);

                // Read the footer to determine the length of the destiantion file  
                //GZIP文件格式说明:  
                //10字节的头，包含幻数、版本号以及时间戳   
                //可选的扩展头，如原文件名   
                //文件体，包括DEFLATE压缩的数据   
                //8字节的尾注，包括CRC-32校验和以及未压缩的原始数据长度(4字节) 文件大小不超过4G   

                //为Data指定byte的长度，故意开大byte数据的范围  
                //读取未压缩的原始数据长度  
                quartetBuffer = new byte[4];
                long position = sourceStream.Length - 4;
                sourceStream.Position = position;
                sourceStream.Read(quartetBuffer, 0, 4);

                int checkLength = BitConverter.ToInt32(quartetBuffer, 0);
                byte[] data;
                if (checkLength <= sourceStream.Length)
                {
                    data = new byte[Int16.MaxValue];
                }
                else
                {
                    data = new byte[checkLength + 100];
                }
                //每100byte从解压流中读出数据，并将读出的数据Copy到Data byte[]中，这样就完成了对数据的解压  
                byte[] buffer = new byte[100];

                sourceStream.Position = 0;

                int offset = 0;
                int total = 0;

                while (true)
                {
                    int bytesRead = decompressedStream.Read(buffer, 0, 100);

                    if (bytesRead == 0)
                        break;

                    buffer.CopyTo(data, offset);

                    offset += bytesRead;
                    total += bytesRead;
                }
                //剔除多余的byte  
                byte[] actualdata = new byte[total];

                for (int i = 0; i < total; i++)
                    actualdata[i] = data[i];

                return actualdata;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("从文件{0}解压数据时发生错误", srcFile), ex);
            }
            finally
            {
                if (sourceStream != null)
                    sourceStream.Close();

                if (decompressedStream != null)
                    decompressedStream.Close();
            }
        }



        /// <summary>  
        /// 将指定的字节数组压缩,并写入到目标文件  
        /// </summary>  
        /// <param name="srcBuffer">指定的源字节数组</param>  
        /// <param name="destFile">指定的目标文件</param>  
        public static void CompressData(byte[] srcBuffer, string destFile)
        {
            FileStream destStream = null;
            GZipStream compressedStream = null;
            try
            {
                //打开文件流  
                destStream = new FileStream(destFile, FileMode.OpenOrCreate, FileAccess.Write);
                //指定压缩的目的流（这里是文件流）  
                compressedStream = new GZipStream(destStream, CompressionMode.Compress, true);
                //往目的流中写数据，而流将数据写到指定的文件  
                compressedStream.Write(srcBuffer, 0, srcBuffer.Length);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("压缩数据写入文件{0}时发生错误", destFile), ex);
            }
            finally
            {
                // Make sure we allways close all streams                 
                if (null != compressedStream)
                {
                    compressedStream.Close();
                    compressedStream.Dispose();
                }

                if (null != destStream)
                    destStream.Close();
            }
        }
    }
}
