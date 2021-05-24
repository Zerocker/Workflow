using System;
using System.Text;

namespace crypto_lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("t > ");
            string text = Console.ReadLine();
            
            Console.Write("k > ");
            string key = Console.ReadLine();
            
            if (text is null || key is null)
                throw new NullReferenceException();

            text = text.PadRight(8, '_');
            key = key.PadRight(8, '_');

            byte[] byteText = To1251(text.Substring(0, 8));
            byte[] byteKey = To1251(key.Substring(0, 8));

            ulong numText = BitConverter.ToUInt64(byteText);
            ulong numKey = BitConverter.ToUInt64(byteKey);
            
            Console.WriteLine($"Text: {numText:x8}");
            Console.WriteLine($"Key: {numKey:x8}");

            ulong numCipher = Des.Encrypt(numText, numKey);
            Console.WriteLine($"Cipher: {numCipher:x8}");
        }

        static byte[] To1251(string source)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            
            byte[] utf8 = Encoding.UTF8.GetBytes(source);
            return Encoding.Convert(Encoding.UTF8, encoding, utf8);
        }
    }
}