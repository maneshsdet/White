using System.Collections.Generic;
using System.IO;

namespace CommonComponents
{
    public static class LoadProperties
    {
        public static Dictionary<string, string> GetProperties(string path)
        {
            string str1 = "";
            using (StreamReader streamReader = new StreamReader(path))
                str1 = streamReader.ReadToEnd().Replace("\r", "");
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (string str2 in str1.Split("\n".ToCharArray()))
            {
                string[] strArray = str2.Split("=".ToCharArray());
                dictionary.Add(strArray[0], strArray[1]);
            }
            return dictionary;
        }
    }
}
