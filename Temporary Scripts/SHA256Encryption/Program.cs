using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SHA256Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string plain_data = "testpaswoord123";
            string salt = getSalt();
            string hashed_data = Encrypt_Data(plain_data + salt);
            
            
            Console.WriteLine("plain_data: {0}", plain_data);
            Console.WriteLine("salt: {0}", salt);
            Console.WriteLine("SHA256: {0}", hashed_data);
            Console.ReadLine();
        }

        public static string Encrypt_Data(string plain_text)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plain_text));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string getSalt()
        {
            var random = new RNGCryptoServiceProvider();

            int max_length = 32;

            byte[] salt = new byte[max_length];

            random.GetNonZeroBytes(salt);

            return Convert.ToBase64String(salt);
        }
    }
}
