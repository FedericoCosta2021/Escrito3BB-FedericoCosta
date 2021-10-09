using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Security.Cryptography;

namespace CapaLogica
{
    public static class CryptographyUtils
    {
        public static string doEncryption(string target)
        {
            byte[] buffer = Encoding.Default.GetBytes(target);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.Key=Encoding.Default.GetBytes("asdfvgbhakudhaj87ahdjakloadakial");
            aes.IV = Encoding.Default.GetBytes("1234567890");

            ICryptoTransform transform = aes.CreateEncryptor();
            byte[] t = transform.TransformFinalBlock(buffer, 0, buffer.Length);
            return @combineFields(aes, t);
        }

        private static string combineFields(AesCryptoServiceProvider aes, byte[] t)
        {
            string @result =
               @Encoding.Default.GetString(t) +
               Convert.ToChar(@Encoding.Default.GetString(t).Length) +
               @Encoding.Default.GetString(aes.Key) +
               Convert.ToChar(@Encoding.Default.GetString(aes.Key).Length) +
               Encoding.Default.GetString(aes.IV) +
               Convert.ToChar(@Encoding.Default.GetString(aes.IV).Length);


            Console.WriteLine($"KEY:{Encoding.Default.GetString(aes.Key)}");
            Console.WriteLine($"KEYSIZE:{Encoding.Default.GetString(aes.Key).Length}");
            Console.WriteLine($"IV:{Encoding.Default.GetString(aes.IV)}");
            Console.WriteLine($"IVSIZE:{Encoding.Default.GetString(aes.IV).Length}");

            return @result;
        }
    }
}