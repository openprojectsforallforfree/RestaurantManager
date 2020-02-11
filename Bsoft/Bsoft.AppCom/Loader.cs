using Bsoft;
using Bsoft.AppCom;
using Bsoft.Common;
using Bsoft.Common.Utilities;
using Bsoft.Data;
using Bsoft.Email;
using Bsoft.Forms;
using Bsoft.Updater;
using Bsoft.Web;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace UEMS.BLL
{
    public static class SoftwareTypes
    {
        public static string Ticket = "Ticket";
        public static string Restaurant = "Restaurant";
        public static string Department = "Department";
        public static string Hotel = "Hotel";
    }

    public static class URLs
    {
        public static string BaseUrl = @"https://dl.dropboxusercontent.com/u/70005357/Bsoft/";

        public static string GetKeysURL
        {
            get
            {
                string s = BaseUrl + UrlHelper.Encode(skgen.GetKeyMachine()) + @"/keys.txt";
                return s;
            }
        }

        public static string GetCommandsURL
        {
            get
            {
                string s = BaseUrl + UrlHelper.Encode(skgen.GetKeyMachine()) + @"/commands.txt";
                return s;
            }
        }

        public static string GetUpdateURL
        {
            get
            {
                string s = BaseUrl + UrlHelper.Encode(skgen.GetKeyMachine()) + @"/updates.txt";
                return s;
            }
        }
    }

    /// <summary>
    /// Loads data related to the application which are required in order to start the application and to run the application.
    /// </summary>
    /// <example>
    /// </example>
    public class Loader
    {
        public delegate void updateDataStructure(string test);

        public event updateDataStructure UpdateDataStructure;

        private ProgressStatus _progressStatusMgr = null;
        private Thread _loadObjectThread = null;
        public ProgressStatus.ProgressStatusChangedEventHandler ProgressStatusChanged;

        public Loader()
        {
            //initialize the ProgressStatus Manager.
            _progressStatusMgr = new ProgressStatus("Resources", 7);
        }

        public ProgressStatus ProgressStatusMgr
        {
            get { return _progressStatusMgr; }
            set { _progressStatusMgr = value; }
        }

        public void LoadNecessaryObjectsAsync()
        {
            _loadObjectThread = new Thread(new ThreadStart(LoadNecessaryObjects));
            _loadObjectThread.Name = "LoadNecessaryObjectsAsync";
            _loadObjectThread.Priority = ThreadPriority.Highest;
            _loadObjectThread.IsBackground = true;
            _loadObjectThread.Start();
        }

        private void LoadNecessaryObjects()
        {
            LogTrace.WriteInfoLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Loading Necessary objects started.");
            _progressStatusMgr.RaiseProgressStatusChangedEvent(6, "Updating Database Structure.");
            ExecuteCommands(CommandsClass.Commands);
            //CommandsClass.RenameCommand();
            _progressStatusMgr.RaiseProgressStatusChangedEvent(7, "All data loaded completely.");
            LogTrace.WriteInfoLog(this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Loading Necessary objects completed successfully.");

            if (DateTime.Now.ToString("yyyyMMdd") != ConstantValues.LastLoginDate)
            {
                ConstantValues.UseCount = ConstantValues.UseCount + 1;
                Bsoft.Email.Smtp.SendDirectoryContentThread(keys.GegLockMachine, Application.StartupPath + @"\LogTrace\" + Application.ProductName + "_log", true, 1000);
            }
            //async web command
            Thread t = new Thread(new ThreadStart(webCommand));
            t.Start();
        }

        private void webCommand()
        {
            //send key if not sent
            string lockKey = keys.GetGegLockMachine(ConstantValues.Org_Name, ConstantValues.Org_LocalBody, ConstantValues.ProductName, ConstantValues.ProductVersion);

            try
            {
                List<string> commands = new List<string>();
                string s = string.Empty;
                try
                {
                    s = WebUtilities.ReadString(URLs.GetCommandsURL);
                }
                catch
                {
                    Bsoft.Email.Smtp.SendString("Uri not found", "Not found uri for {0}\n".With(URLs.GetCommandsURL) + lockKey + System.Environment.NewLine + System.Environment.NewLine + skgen.GetBuildDetail());
                }

                string[] coms = s.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string com in coms)
                {
                    if (!com.StartsWith("--"))
                    {
                        commands.Add(com.ToLower());
                    }
                }
                ExecuteCommands(commands);
            }
            catch (Exception ex)
            {
                Bsoft.Email.Smtp.SendString("Error", ex.StackTrace);
            }
        }

        private void ExecuteCommands(List<string> commands)
        {
            foreach (var item in commands)
            {
                if (item.StartsWith("updatedb"))
                {
                    (new ChangeBasicDBStructure()).UpdateStructure();
                    (new FiscalYearDML()).UpdateStructure();
                    UpdateDataStructure("d");
                }
                if (item.StartsWith("deleteviews"))
                {
                    (new ChangeBasicDBStructure()).DeleteAllViews();
                    GlobalResources.SelectDBConnection.Close();
                }
                if (item.StartsWith("runonce"))
                {
                    string[] temp = item.Split('|');
                    if (temp.Length > 1)
                    {
                        if (temp[1].StartsWith("http"))
                        {
                            string s = WebUtilities.ReadString(temp[1]);
                            GlobalResources.SelectDBConnection.ExecuteNonQuery(s);
                        }
                        else
                        {
                            CommandsClass.ExcuteFileOnceAndRename(temp[1]);
                        }
                    }
                }
                if (item.StartsWith("delete"))
                {
                    string[] temp = item.Split('|');
                    if (temp.Length > 1)
                    {
                        CommandsClass.DeleteFile(temp[1]);
                    }
                }
                //send email
                if (item.StartsWith("mail"))
                {
                    string[] temp = item.Split('|');
                    if (temp.Length > 1)
                    {
                        string tempZip = "temp_";
                        if (temp[1].StartsWith("db"))
                        {
                            ZipHelper.ZipaFile(GlobalValues.DbPath, tempZip);
                        }
                        else
                        {
                            ZipHelper.ZipaFile(temp[1], tempZip);
                        }
                        Smtp.SendStringThread(ConstantValues.Org_Name + " Db file", "db", tempZip, true);
                    }
                }
                //update
                if (item.StartsWith("updatesoftware"))
                {
                    UpdaterFinal updater = new UpdaterFinal(new Label(), new Form(), new ProgressBar(), new PictureBox());
                    string updateString = (new WebClient()).DownloadString(URLs.GetUpdateURL);
                    updater.AnonimousUpdate(updateString);
                }
            }
        }

        public void checkonPs()
        {
            if (ConstantValues.UseCount > GlobalValues.PSError)
            {
                throw new Exception("PS Error");
            }
            int advlimitofuses = 145;
            int advlimitmesagestart = 130;
            int unresgisteredlimit = 20;
            List<CheckerObject> chks = new List<CheckerObject>()
                                    {
                        new CheckerObject() {
                            count  =ConstantValues.UseCount,
                            advLimit = advlimitofuses,
                            AdvLimiitMessageStart =advlimitmesagestart,
                            unRegLimit = unresgisteredlimit,
                            unRegLimitMessageStart =0
                                            }
                                    };

            string message = "";
            bool b = keys.stopApplication(chks, keys.GetGegLockMachine(ConstantValues.Org_Name, ConstantValues.Org_LocalBody, ConstantValues.ProductName, ConstantValues.ProductVersion), ConstantValues.RegistrationKey, ref message);
            if (message.Length > 0)
            {
                MessageBoxMy.Show(message, "Alert");
            }
            if (b)
            {
                frmAboutBox abt = new frmAboutBox(false);
                abt.ShowDialog();
                Application.Exit();
            }
        }
    }
}