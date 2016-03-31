using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GZipHelperLib.Tools
{
    public class AESTools
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







        public static string decryption(string strkey, string readfile)
        {
            try
            {
                RijndaelManaged rij = new RijndaelManaged();
                rij.KeySize = 256;
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

                string rtnstr = "";
                int length;
                //while ((length = cs.ReadByte()) != -1)
                //fswrite.WriteByte((byte)length);
                while ((length = cs.Read(buffer, 0, 4096)) > 0)
                {
                    rtnstr += System.Text.Encoding.Default.GetString(buffer);

                }
                cs.Close();
                fsopen.Close();
                return rtnstr;
            }
            catch (Exception e)
            {
                return null;
            }
        }




        public static string Encrypt(string toEncrypt,string password)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(MD5Tools.MD5Encrypt(password));
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }


        public static string Decrypt(string toDecrypt, string password)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(MD5Tools.MD5Encrypt(password));
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}
