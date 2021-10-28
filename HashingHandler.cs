using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bad_eend
{
    public class HashingHandler
    {
        public string Encrypt_Data(string plain_text)
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
        public string getSalt()
        {
            var random = new RNGCryptoServiceProvider();

            int max_length = 32;

            byte[] salt = new byte[max_length];

            random.GetNonZeroBytes(salt);

            return Convert.ToBase64String(salt);
        }
    }
}
