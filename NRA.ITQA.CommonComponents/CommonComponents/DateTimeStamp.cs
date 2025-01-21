using System;
using System.Globalization;

namespace CommonComponents
{
    public static class DateTimeStamp
    {
        public static string getTimeStamp(string format)
        {
            try
            {
                return DateTime.Now.ToString(format);
            }
            catch (Exception)
            {
                return DateTime.Now.ToString();
            }
        }

        public static string FutureTimeStamp(string format, int days)
        {
            try
            {
                return DateTime.Now.AddDays(days).ToString(format);
            }
            catch (Exception)
            {
                return DateTime.Now.ToString();
            }
        }

        public static string DateWithoutLeadingZeros(string date, string format)
        {
            try
            {
                DateTime d = DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);
                return (d.ToString(format));
            }
            catch (Exception)
            {
                return date;
            }
        }
    }
}
