using System;
using System.Collections.Generic;
using System.Text;

namespace GZipHelperLib.Tools
{
    class ByteArray
    {
        private byte[] m_data = null;
        public ByteArray(byte[] data)
        {
            m_data = data;
        }
        public byte[] getBytes()
        {
            return m_data;
        }
        static public ByteArray operator +(ByteArray a, ByteArray b)
        {
            byte[] xxoo1 = a.getBytes();
            byte[] xxoo2 = b.getBytes();
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                ms.Write(xxoo1, 0, xxoo1.Length);
                ms.Write(xxoo2, 0, xxoo2.Length);
                return new ByteArray(ms.ToArray());
            }
        }
    }
}
