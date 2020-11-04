using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.Models
{
    public class HashComputer
    {
        /**
         * Description: Generates a hash in bytes for the source string
         * Parameters:
         * - inputString: source string
         * Return: Array of bytes
         */
        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }


        /**
         * Description: Generates a hash string for the source string
         * Parameters:
         * - inputString: source string
         * Return: hash string
         */
        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}
