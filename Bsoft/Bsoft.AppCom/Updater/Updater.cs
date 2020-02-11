using Bsoft.AppCom;
using Bsoft.Common;
using Bsoft.Forms;
using Bsoft.Threading;
using Bsoft.Web;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using UEMS.BLL;

namespace Bsoft.Updater
{
    public class UpdaterFinal
    {
        private Label lblUpdateResult;
        private Form form;
        private ProgressBar progressBar1;
        private PictureBox pictureUpdateGif;

        public UpdaterFinal(Label lblUpdateResult, Form form, ProgressBar progressBar1, PictureBox pictureUpdateGif)
        {
            this.lblUpdateResult = lblUpdateResult;
            this.form = form;
            this.progressBar1 = progressBar1;
            this.pictureUpdateGif = pictureUpdateGif;
        }

        public void updateClicked()
        {
            try
            {
                preDownload();
                ThreadUtilities.SetVisible(form, pictureUpdateGif, false);
                ThreadUtilities.SetVisible(form, progressBar1, true);
                form.Invalidate();
                bw.DoWork -= new DoWorkEventHandler(backgroundWorker);
                bw.DoWork += new DoWorkEventHandler(backgroundWorker);
                bw.WorkerSupportsCancellation = true;
                bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                LogTrace.WriteErrorLog(ex.Message);
                MessageBoxMy.Show("Could not update the application. " + ex.Message);
            }
        }

        public UpdateClass commandInfo = new UpdateClass();
        private BackgroundWorker bw = new BackgroundWorker();

        public void checkUpdates()
        {
            var t = new Thread(() => checkupate());
            t.Start();
        }

        private void checkupate()
        {
            UpdaterForm(
                Path.GetFileNameWithoutExtension(Application.ExecutablePath),
                URLs.GetUpdateURL,
                ConstantValues.BuildNumber
                );
        }

        public bool checkUpdateSilent()
        {
            return false;
        }

        private void UpdaterForm(string procestoEnd, string updateInfoURL, double currentBuildNumber)
        {
            bw.WorkerSupportsCancellation = true;
            commandInfo.ProcessToEnd = procestoEnd;
            commandInfo.UpdateInfoFileURL = updateInfoURL;
            commandInfo.OldBuildNumber = currentBuildNumber;

            Thread th = new Thread(new ThreadStart(() => GetUpdateInfo()));
            th.IsBackground = true;
            th.Start();
        }

        private void GetUpdateInfo()
        {
            ThreadUtilities.SetText(form, lblUpdateResult, "Checking new updates...");
            WebClient client = new WebClient();
            try
            {
                string s = client.DownloadString(commandInfo.UpdateInfoFileURL);
                commandInfo.Populate(s);
                if (commandInfo.NewBuildNumber > commandInfo.OldBuildNumber)
                {
                    string message = "New update are available.\n{0}\nPlease Click Ok to proceed.\nThe application will Restart After completing download.".With(commandInfo.NewFeatures);
                    if (MessageBoxMy.Show(message, MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        updateClicked();
                    }
                }
                else
                {
                    ThreadUtilities.SetText(form, lblUpdateResult, "Your software is latest version.");
                    ThreadUtilities.SetVisible(form, pictureUpdateGif, false);
                }
            }
            catch (Exception ex)
            {
                ThreadUtilities.SetVisible(form, pictureUpdateGif, false);
                if (ex.Message.Contains("The remote name could not be resolved"))
                {
                    ThreadUtilities.SetText(form, lblUpdateResult, "No internet connection to check for updates.");
                }
                else
                {
                    ThreadUtilities.SetText(form, lblUpdateResult, "Error:" + ex.Message);
                }
            }
        }

        private void backgroundWorker(object sender, DoWorkEventArgs e)
        {
            try
            {
                //download
                WebUtilities.bytesDownloaded += Bytesdownloaded;
                ThreadUtilities.SetText(form, lblUpdateResult, "Downloading new updates");
                try
                {
                    if (!WebUtilities.DownloadFromWeb(commandInfo.NewBuildURL, commandInfo.TempDownloadFolder))
                    {
                        ThreadUtilities.SetText(form, lblUpdateResult, "Could not download...");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxMy.ShowError(ex.Message);
                    return;
                }
                //unzip
                ThreadUtilities.SetText(form, lblUpdateResult, "Unzipping package...");
                Thread.Sleep(1000);
                ZipHelper.UnZip(commandInfo.DownloadFile, commandInfo.TempDownloadFolder);
                Thread.Sleep(1000);
                File.Delete(commandInfo.DownloadFile);
                ThreadUtilities.SetText(form, lblUpdateResult, "Closing application and installing updates...");

                //call updaeter app
                ProcessStartInfo startInfo = new ProcessStartInfo();
                commandInfo.UpdaterApp = "updater.exe";
                startInfo.FileName = commandInfo.UpdaterApp;
                startInfo.Arguments = GetCommandText();
                Thread.Sleep(1000);
                Process.Start(startInfo);
                Thread.Sleep(1000);
                ThreadUtilities.CloseApplications(form);
                Application.Exit();
            }
            catch (Exception ex)
            {
                LogTrace.WriteErrorLog(ex.Message);
                MessageBoxMy.Show("Could not update the application. " + ex.Message);
            }
        }

        #region Helpers

        private void preDownload()
        {
            //commandInfo.Populate (commandInfo.ApplicationFolder, commandInfo.VersionFile);
            if (!Directory.Exists(commandInfo.TempDownloadFolder)) Directory.CreateDirectory(commandInfo.TempDownloadFolder);
            try
            {
                if (Directory.Exists(commandInfo.TempDownloadFolder))
                {
                    Directory.Delete(commandInfo.TempDownloadFolder, true);
                }

                Directory.CreateDirectory(commandInfo.TempDownloadFolder);
            }
            catch { }
        }

        private void postDownload()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = commandInfo.PostProcessFile;
            startInfo.Arguments = commandInfo.PostProcessCommand;
            Process.Start(startInfo);
        }

        private void Bytesdownloaded(ByteArgs e)
        {
            ThreadUtilities.SetProgress(form, progressBar1, lblUpdateResult, e.total, e.downloaded);
        }

        private string GetCommandText()
        {
            //backup|true|removeold|false|backupfolder|D:\test\|tempDownloadFolder|D:\test\|destinationFolder|D:\test\|dateInfo|20131212|
            string cmdLn = "";

            cmdLn += "|backup|" + commandInfo.Backup.ToString();
            cmdLn += "|removeold|" + commandInfo.RemoveAllOld.ToString();
            cmdLn += "|backupfolder|" + commandInfo.BackupFolderRoot;
            cmdLn += "|tempDownloadFolder|" + commandInfo.TempDownloadFolderRoot;
            cmdLn += "|destinationFolder|" + commandInfo.ApplicationFolder;
            cmdLn += "|dateInfo|" + DateTime.Now.ToString("yyyyMMdd");
            cmdLn += "|postprocess|" + commandInfo.PostProcessFile;
            cmdLn += "|postprocessCommand|" + commandInfo.PostProcessCommand;
            cmdLn += "|newbuildNumber|" + commandInfo.NewBuildNumber;
            return string.Format("\"{0}\"", cmdLn);
        }

        #endregion Helpers

        public void AnonimousUpdate(string updateString)
        {
            commandInfo.Populate(updateString);
            commandInfo.ProcessToEnd = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
            commandInfo.OldBuildNumber = ConstantValues.BuildNumber;
            if (commandInfo.NewBuildNumber > commandInfo.OldBuildNumber)
            {
                updateClicked();
            }
        }
    }
}