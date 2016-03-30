using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GZipHelperLib.Tools
{
    public class MD5Tools
    {
        public static string MD5Encrypt(string strText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(strText));
            return System.Text.Encoding.Default.GetString(result);
        }
    }
}
