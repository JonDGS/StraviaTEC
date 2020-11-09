using System;
using System.Collections.Generic;
using System.Text;

namespace Feria_Virtual_REST.Models
{
    public static class TokenManager
    {

        /**
         * Description: Generates a random ID for an order
         * Parameters:
         * - size: size of string
         * Return: Generate ID
         */
        public static string generateToken(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }
    }
}
