using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;

namespace CommonComponents
{
    public static class FileOperations
    {
        public static string _lastError = "";
        public static string WriteToFile(string filename, string text)
        {
            string temp = @"\\nraqaauto1\Automation\TempFiles\" + filename;
            if (!File.Exists(temp))
            {
                File.WriteAllText(temp, "This is file was created on: " + DateTime.Now + Environment.NewLine);
            }

            File.AppendAllText(temp, text + Environment.NewLine);
            return temp;
        }

        public static string GetFile(string partialtext)
        {
            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(@"\\nraqaauto1\Automation\PDFDownloads");
            FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + partialtext + "*.*");

            foreach (FileInfo foundFile in filesInDir)
            {
                string fullName = foundFile.FullName;
                return fullName;
            }
            return null;
        }

        public static void DeleteFiles()
        {
            try
            {
                if (Directory.GetFiles(@Constants.Properties["DefaultDirectory"]).Count() > 0)
                    Directory.GetFiles(@Constants.Properties["DefaultDirectory"]).ToList().ForEach(File.Delete);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static bool SetEveryoneAccess(string dirName)
        {
            // Make sure directory exists
            try
            {
                if (Directory.Exists(dirName) == false)
                    throw new Exception(string.Format("Directory {0} does not exist, so permissions cannot be set.", dirName));

                // Get directory access info
                DirectoryInfo dinfo = new DirectoryInfo(dirName);
                DirectorySecurity dSecurity = dinfo.GetAccessControl();

                // Add the FileSystemAccessRule to the security settings. 
                dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));

                // Set the access control
                dinfo.SetAccessControl(dSecurity);

                _lastError = String.Format("Everyone FullControl Permissions were set for directory {0}", dirName);
                return true;
            }
            catch (Exception ex)
            {
                _lastError = ex.Message;
                return false;
            }

        }
    }
}
