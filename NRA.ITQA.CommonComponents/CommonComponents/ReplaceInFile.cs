using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CommonComponents
{
    public static class ReplaceInFile
    {
        public static void ReplaceTextInFile(string filePath, string findText, string replaceText)
        {
            try
            {
                StreamReader streamReader = new StreamReader(filePath);
                string end = streamReader.ReadToEnd();
                streamReader.Close();
                string str = Regex.Replace(end, findText, replaceText);
                StreamWriter streamWriter = new StreamWriter(filePath);
                streamWriter.Write(str);
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static string ReadTextInFile(string filePath)
        {
            StreamReader streamReader = new StreamReader(filePath);
            string end = streamReader.ReadToEnd();
            streamReader.Close();
            return end;
        }

        public static void ReplaceTextBetweenTwoStrings(
          string filePath,
          string starttext,
          string endtext,
          string replaceText)
        {
            try
            {
                StreamReader streamReader = new StreamReader(filePath);
                string end = streamReader.ReadToEnd();
                streamReader.Close();
                string str = new Regex(starttext + "([^" + endtext + "]+)" + endtext).Replace(end, replaceText);
                StreamWriter streamWriter = new StreamWriter(filePath);
                streamWriter.Write(str);
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
