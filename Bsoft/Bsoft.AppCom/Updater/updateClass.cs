using Bsoft.Common;
using System;
using System.IO;
using System.Windows.Forms;

namespace Bsoft.Updater
{
    public class UpdateClass
    {
        private ParserClass parser;

        public void Populate(string inputString)
        {
            parser = new ParserClass(inputString);
        }

        public void Populate(string dir, string file)
        {
            Populate(System.IO.File.ReadAllText(Path.Combine(dir, file)));
        }

        public double OldBuildNumber = 0;

        public string VersionFile
        {
            get { return UpdateInfoFileURL.Substring(UpdateInfoFileURL.LastIndexOf('/') + 1); }
        }

        public double NewBuildNumber
        {
            get { return double.Parse(parser.GetValue("newbuildnumber")); }
        }

        public string ApplicationFolder
        {
            get
            {
                return Application.StartupPath + @"\";
            }
        }

        public string BackupFolder
        {
            get
            {
                return BackupFolderRoot + DateTime.Now.ToString("yyyyMMdd") + @"\";
            }
        }

        public string TempDownloadFolder
        {
            get
            {
                return TempDownloadFolderRoot + DateTime.Now.ToString("yyyyMMdd") + @"\";
            }
        }

        public string BackupFolderRoot
        {
            get
            {
                string s = parser.GetValue("backupfolder");
                if (s.Length < 1)
                {
                    return Application.StartupPath + "\\buildbakup\\";
                }
                else
                {
                    return s;
                }
            }
        }

        public string TempDownloadFolderRoot
        {
            get
            {
                string s = parser.GetValue("tempdownloadfolder");
                if (s.Length < 1)
                {
                    return Application.StartupPath + "\\tempdownloadfolder\\"; ;
                }
                else
                {
                    return s;
                }
            }
        }

        public string UpdaterApp
        {
            get;
            set;
        }

        public string ProcessToEnd
        {
            get;
            set;
        }

        public string UpdateInfoFileURL
        {
            get;
            set;
        }

        public string PostProcessFile
        {
            get
            {
                if (parser.GetValue("postProcessFile").Trim().Length < 1)
                {
                    return ProcessToEnd;
                }
                else
                {
                    return parser.GetValue("postProcessFile").Trim();
                }
            }
        }

        public string PostProcessCommand
        {
            get { return parser.GetValue("postProcessCommand"); }
        }

        public string DownloadFile
        {
            get
            {
                string fn = NewBuildURL.Substring(NewBuildURL.LastIndexOf('/') + 1);
                return TempDownloadFolder + fn;
            }
        }

        public string NewBuildURL
        {
            get { return parser.GetValue("newbuildurl"); }
        }

        public bool Backup
        {
            get
            {
                string s = parser.GetValue("backup");
                if (s.ToLower() == "false")
                {
                    return false;
                }
                return true;
            }
        }

        public bool RemoveAllOld
        {
            get
            {
                string s = parser.GetValue("removeallold");
                if (s.ToLower() == "true")
                {
                    return true;
                }
                return false;
            }
        }

        public string NewFeatures
        {
            get
            {
                return parser.GetValue("newfeatures");
            }
        }
    }
}