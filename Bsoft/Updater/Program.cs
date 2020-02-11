using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using WindowsFormsApplication1;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new UpdaterClass(args[0]).ProcessAhead();
        }
    }

    public class UpdaterClass
    {
        private bool Backup = false;
        private bool RemoveAllOld = false;
        private string backupfolder = "";
        private string tempDownloadFolder = "";
        private string destinationFolder = "";
        private string dateInfo = "";
        private string postProcess = "";
        private string postProcessCommand = "";
        private string newbuildNumber = "";

        public UpdaterClass(string info)
        {
            populateVariables(info);
        }

        public void ProcessAhead()
        {
            //Kill process main
            try
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process process in processes)
                {
                    if (process.ProcessName == postProcess)
                    {
                        process.Kill();
                    }
                }
            }
            catch (Exception)
            { }

            //backupOld, bool completlyNew, string backupFolder,
            //string tempDownloadFolder,
            //string destinationFolder,
            //string dateValue
            moveFiles(Backup, RemoveAllOld, backupfolder, tempDownloadFolder, destinationFolder, DateTime.Now.ToString("yyyyMMdd"));

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = postProcess;
            if (startInfo != null)
            {
                startInfo.Arguments = newbuildNumber + "|" + postProcessCommand;
            }
            Process.Start(startInfo);
        }

        private void moveFiles(bool backupOld, bool completlyNew, string backupFolder, string tempDownloadFolder, string destinationFolder, string dateValue)
        {
            if (!backupFolder.EndsWith("\\"))
            {
                backupFolder = backupFolder + "\\";
            }
            if (!tempDownloadFolder.EndsWith("\\"))
            {
                tempDownloadFolder = tempDownloadFolder + "\\";
            }
            if (!destinationFolder.EndsWith("\\"))
            {
                destinationFolder = destinationFolder + "\\";
            }
            List<string> excludelist = new List<string>();
            excludelist.Add(tempDownloadFolder.ToLower());
            excludelist.Add(backupFolder.ToLower());

            //optionally backup old
            if (backupOld)
            {
                FileUtility.CopyDirectory(destinationFolder, backupFolder + dateValue, excludelist);
                //foreach (string fi in Directory.GetFiles(destinationFolder))
                //{
                //    string f = Path.GetFileName(fi);
                //    File.Copy(fi, Path .Combine ( backupFolder , f), true);
                //}
            }
            //optionally delete olds
            if (completlyNew)
            {
                foreach (string fi in Directory.GetFiles(destinationFolder))
                {
                    if (fi.ToLower() != System.Reflection.Assembly.GetExecutingAssembly().Location.ToLower())
                    {
                        try
                        {
                            File.Delete(fi);
                        }
                        catch { }
                    }
                }
                foreach (string fi in Directory.GetDirectories(destinationFolder))
                {
                    if (!excludelist.Contains((fi + "\\").ToLower()))
                    {
                        try
                        {
                            Directory.Delete(fi, true);
                        }
                        catch { }
                    }
                }
            }

            //copy new files
            FileUtility.CopyDirectory(tempDownloadFolder + dateValue, destinationFolder);
            //foreach (string fi in Directory.GetFiles(tempDownloadFolder))
            //{
            //    string f = Path.GetFileName(fi);
            //    File.Copy(fi, Path.Combine(destinationFolder, f), true);
            //}
            //delete tempdownloadfolder
            try
            {
                Directory.Delete(tempDownloadFolder, true);
            }
            catch { }
        }

        //Updater Command lines
        //They are pipe delimited eg:
        //backup|true|removeold|false|backupfolder|D:\test\|tempDownloadFolder|D:\test\|destinationFolder|D:\test\|dateInfo|20131212|
        //Commands:All required
        //________
        //|backup|true false
        //removeold|true false
        //backupfolder|folder for backup
        //tempDownloadFolder|tempdownload folder
        //destinationFolder|destination folder generally applicaiton folder
        //dateInfo|date
        private List<string> populateVariables(string infoLine)
        {
            infoLine = infoLine.ToLower();
            List<string> tempList = new List<string>();
            string[] part = infoLine.Split('|');
            for (int i = 0; i < part.Length; i++)
            {
                if (part[i].Trim() == "backup".ToLower())
                {
                    if (part[i + 1].Trim() == "true".ToLower())
                    {
                        Backup = true;
                    }
                    else
                    {
                        Backup = false;
                    }
                }

                if (part[i].Trim() == "removeold".ToLower())
                {
                    if (part[i + 1].Trim() == "true".ToLower())
                    {
                        RemoveAllOld = true;
                    }
                    else
                    {
                        RemoveAllOld = false;
                    }
                }
                if (part[i].Trim() == "backupfolder".ToLower())
                {
                    backupfolder = part[i + 1].Trim();
                }
                if (part[i].Trim() == "tempDownloadFolder".ToLower())
                {
                    tempDownloadFolder = part[i + 1].Trim();
                }
                if (part[i].Trim() == "destinationFolder".ToLower())
                {
                    destinationFolder = part[i + 1].Trim();
                }
                if (part[i].Trim() == "dateInfo".ToLower())
                {
                    dateInfo = part[i + 1].Trim();
                }
                if (part[i].Trim() == "postprocess".ToLower())
                {
                    postProcess = part[i + 1].Trim();
                }
                if (part[i].Trim() == "postprocessCommand".ToLower())
                {
                    postProcessCommand = part[i + 1].Trim();
                }
                if (part[i].Trim() == "newbuildNumber".ToLower())
                {
                    newbuildNumber = part[i + 1].Trim();
                }
            }
            return tempList;
        }
    }
}