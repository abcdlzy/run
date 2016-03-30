using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GZipHelperLib.Tools
{
    class AESTools
    {
        public static bool encryption(string strkey, string readfile, string writefile)
        {
            try
            {
                RijndaelManaged rij = new RijndaelManaged();
                //byte[] key = rij.Key;
                byte[] key = Encoding.UTF8.GetBytes(strkey);
                byte[] iv = rij.IV;
                byte[] buffer = new byte[4096];
                Rijndael crypt = Rijndael.Create();
                ICryptoTransform transform = crypt.CreateEncryptor(key, iv);
                //写进文件
                FileStream fswrite = new FileStream(writefile, FileMode.Create);
                CryptoStream cs = new CryptoStream(fswrite, transform, CryptoStreamMode.Write);
                //打开文件
                FileStream fsread = new FileStream(readfile, FileMode.Open);

                /*------------------定位要加密的部分-----------------*/
                long _file_size = fsread.Length;
                byte[] _header = new byte[8];
                //定位GUID
                fsread.Seek(16, SeekOrigin.Begin);
                //读取header size
                fsread.Read(_header, 0, _header.Length);
                //头部长度
                long _header_size = (long)BitConverter.ToInt32(_header, 0);
                byte[] _header_buffer = new byte[_header_size];
                fsread.Seek(0, SeekOrigin.Begin);
                fsread.Read(_header_buffer, 0, _header_buffer.Length);
                //头部写入新文件
                fswrite.Write(_header_buffer, 0, _header_buffer.Length);
                //定位到头部，准备读取需要加密的部分
                fsread.Seek(_header_size, SeekOrigin.Begin);
                /*-----------------定位加密部分完成-------------------*/
                int length;
                //while ((length = fsread.ReadByte()) != -1)
                //cs.WriteByte((byte)length);
                while ((length = fsread.Read(buffer, 0, 4096)) > 0)
                {
                    cs.Write(buffer, 0, (int)length);
                }

                fsread.Close();
                cs.Close();
                fswrite.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        //用于解密的函数
        public static bool decryption(string strkey, string readfile, string writefile)
        {
            try
            {
                RijndaelManaged rij = new RijndaelManaged();
                rij.KeySize=256;
                //byte[] key = rij.Key;
                byte[] key = Encoding.UTF8.GetBytes(strkey);
                byte[] iv = rij.IV;
                byte[] buffer = new byte[4096];
                Rijndael crypt = Rijndael.Create();
                ICryptoTransform transform = crypt.CreateDecryptor(key, iv);
                //读取加密后的文件 
                FileStream fsopen = new FileStream(readfile, FileMode.Open);
                CryptoStream cs = new CryptoStream(fsopen, transform, CryptoStreamMode.Read);
                //把解密后的结果写进文件
                FileStream fswrite = new FileStream(writefile, FileMode.OpenOrCreate);
                /*------------------定位要解密的部分-----------------*/
                long _file_size = fsopen.Length;
                byte[] _header = new byte[8];
                //定位GUID
                fsopen.Seek(16, SeekOrigin.Begin);
                //读取header size
                fsopen.Read(_header, 0, _header.Length);
                //头部长度
                long _header_size = (long)BitConverter.ToInt32(_header, 0);
                byte[] _header_buffer = new byte[_header_size];
                fsopen.Seek(0, SeekOrigin.Begin);
                fsopen.Read(_header_buffer, 0, _header_buffer.Length);
                //头部写入新文件
                fswrite.Write(_header_buffer, 0, _header_buffer.Length);
                //定位到头部，准备读取需要加密的部分
                fsopen.Seek(_header_size, SeekOrigin.Begin);
                /*-----------------定位要解密的部分完成-------------------*/

                int length;
                //while ((length = cs.ReadByte()) != -1)
                //fswrite.WriteByte((byte)length);
                while ((length = cs.Read(buffer, 0, 4096)) > 0)
                {
                    fswrite.Write(buffer, 0, (int)length);
                }
                fswrite.Close();
                cs.Close();
                fsopen.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
