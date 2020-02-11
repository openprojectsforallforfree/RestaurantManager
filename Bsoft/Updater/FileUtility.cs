using System.Collections.Generic;
using System.IO;

namespace WindowsFormsApplication1
{
    public static class FileUtility
    {
        public static void CopyDirectory(string sourceDir, string destinationDr)
        {
            CopyDirectory(sourceDir, destinationDr, new List<string>());
        }

        public static void CopyDirectory(string sourceDir, string destinationDr, List<string> excludeFolders)
        {
            DirectoryInfo source = new DirectoryInfo(sourceDir);
            DirectoryInfo destination = new DirectoryInfo(destinationDr);
            if (!destination.Exists)
            {
                destination.Create();
            }

            // Copy all files.
            FileInfo[] files = source.GetFiles();
            foreach (FileInfo file in files)
            {
                file.CopyTo(Path.Combine(destination.FullName,
                    file.Name), true);
            }

            // Process subdirectories.
            DirectoryInfo[] dirs = source.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                bool exclude = false;
                // Get destination directory.
                string destinationDir = Path.Combine(destination.FullName, dir.Name);
                // Call CopyDirectory() recursively.
                foreach (string item in excludeFolders)
                {
                    string a = Path.GetFullPath(item).ToLower();
                    string b = (Path.GetFullPath(dir.FullName) + "\\").ToLower();
                    if (b.StartsWith(a))
                    {
                        exclude = true;
                        break;
                    }
                }
                if (!exclude)
                {
                    CopyDirectory(dir.FullName, destinationDir);
                }
            }
        }
    }
}