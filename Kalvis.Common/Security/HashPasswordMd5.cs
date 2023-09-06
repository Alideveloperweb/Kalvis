using System.Security.Cryptography;
using System.Text;

namespace Kalvis.Common.Security
{
    public static class HashPasswordMd5
    {
        public static string EncodePasswordMd5(this string Password)
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(Password);
            encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes);
        }
    }
}
