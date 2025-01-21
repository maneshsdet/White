using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CommonComponents
{
    public static class PasswordGenerator
    {

        public static string RandomPassword(int length)
        {
            string sc = "!@#$%^&*~";
            string num = "0123456789";
            string lowercase = "abcdefghijklmnopqrstuvwxyz";
            Random ran = new Random();
            using var crypto = new RNGCryptoServiceProvider();
            var bits = (length * 6);
            var byte_size = ((bits + 7) / 8);
            var bytesarray = new byte[byte_size];
            crypto.GetBytes(bytesarray);
            string password = Convert.ToBase64String(bytesarray) + sc.ElementAt(ran.Next(1, sc.Length));
            if (!password.Any(char.IsLower))
                password += num.ElementAt(ran.Next(1, lowercase.Length));
            if (!password.Any(char.IsDigit))
                password += num.ElementAt(ran.Next(1, num.Length));

            return password;
        }
    }
}
