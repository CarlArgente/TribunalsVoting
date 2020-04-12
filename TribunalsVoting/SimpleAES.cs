using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Cryptography;
using System.IO;

namespace TribunalsVoting
{
    class SimpleAES
    {
        private static byte[] key = { 242, 69, 244, 208, 152, 51, 76, 39, 84, 17, 183, 88, 135, 218, 64, 154, 152, 41, 51, 30, 164, 92, 146, 51, 118, 244, 198, 176, 102, 189, 134, 236 };

        private static byte[] vector = { 19, 52, 83, 151, 250, 129, 44, 71, 254, 149, 251, 18, 111, 15, 2, 168 };

        private ICryptoTransform encryptor, decryptor;
        private UTF8Encoding encoder;

        public SimpleAES()
        {
            RijndaelManaged rm = new RijndaelManaged();
            encryptor = rm.CreateEncryptor(key, vector);
            decryptor = rm.CreateDecryptor(key, vector);
            encoder = new UTF8Encoding();
        }

        public string Encrypt(string unencrypted)
        {
            return Convert.ToBase64String(Encrypt(encoder.GetBytes(unencrypted)));
        }

        public string Decrypt(string encrypted)
        {
            return encoder.GetString(Decrypt(Convert.FromBase64String(encrypted)));
        }

        public byte[] Encrypt(byte[] buffer)
        {
            return Transform(buffer, encryptor);
        }

        public byte[] Decrypt(byte[] buffer)
        {
            return Transform(buffer, decryptor);
        }

        protected byte[] Transform(byte[] buffer, ICryptoTransform transform)
        {
            MemoryStream stream = new MemoryStream();
            using (CryptoStream cs = new CryptoStream(stream, transform, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
            }
            return stream.ToArray();
        }
    }
}
