using System;
using System.Security.Cryptography;

namespace CommonComponents
{
    public static class PhoneNumberGenerator
    {
        public static string PhoneNumber()
        {
            string phonenum = "";
            for (int i = 0; i < 10; i++)
            {
                phonenum = DateTime.UtcNow.Ticks.ToString().Substring(8);
                if (!phonenum.StartsWith("0"))
                    return phonenum;
            }
            return phonenum;

            //var bytes = new byte[4];
            //var rng = RandomNumberGenerator.Create();
            //rng.GetBytes(bytes);
            //uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
            //return String.Format("{0:D10}", random);
        }

        public static string PhoneNumber_9()
        {
            string phonenum = "";
            for (int i = 0; i < 9; i++)
            {
                phonenum = DateTime.UtcNow.Ticks.ToString().Substring(9);
                if (!phonenum.StartsWith("0"))
                    return phonenum;
            }
            return phonenum;

            //var bytes = new byte[4];
            //var rng = RandomNumberGenerator.Create();
            //rng.GetBytes(bytes);
            //uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
            //return String.Format("{0:D10}", random);
        }
    }
}
