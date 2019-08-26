using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Password
    {
        public static string RandomPassword(int length = 15)
        {
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random     = new Random();

            char[] chars = new char[length];

            for (int i = 0; i < length; i++)
                chars[i] = validChars[random.Next(0, validChars.Length)];

            return new string(chars);
        }
    }
}
