using System.IO;
using System.Threading;

namespace Bsoft.Email
{
    public static class Smtp
    {
        private static string fromEmailAddress = "bajrasoft@gmail.com";
        private static string toEmailAddress = "bajrasoft@gmail.com";
        private static string userName = "bajrasoft";
        private static string pw = "s@lech0r";

        public static bool SendString(string subject, string body)
        {
            return SendString(subject, body, "", false);
        }

        private static bool SendString(string subject, string body, string attachFile, bool deleteAttatchedFile)
        {
            bool functionReturnValue = false;
            //Source code 'Create a mail message object
            System.Net.Mail.MailMessage MyMailMessage = new System.Net.Mail.MailMessage();
            MyMailMessage.IsBodyHtml = false;
            MyMailMessage.Priority = System.Net.Mail.MailPriority.Normal;
            MyMailMessage.From = new System.Net.Mail.MailAddress(fromEmailAddress);
            MyMailMessage.To.Add(toEmailAddress);
            MyMailMessage.Subject = subject;
            MyMailMessage.Body = body;
            if (attachFile.Length > 1)
            {
                MyMailMessage.Attachments.Add(new System.Net.Mail.Attachment(attachFile));
            }
            //Dim sAttach As String
            //sAttach = "C:\j\j.jpg"
            //MyMailMessage.Attachments.Add(New System.Net.Mail.Attachment(sAttach))

            //SMTP Client and SMTP Gmail server
            System.Net.Mail.SmtpClient SMTPServer = new System.Net.Mail.SmtpClient("smtp.gmail.com");

            SMTPServer.Port = 587;
            SMTPServer.Credentials = new System.Net.NetworkCredential(userName, pw);
            SMTPServer.EnableSsl = true;

            try
            {
                SMTPServer.Send(MyMailMessage);
                if (deleteAttatchedFile)
                {
                    System.IO.File.Delete(attachFile);
                }
                functionReturnValue = true;
            }
            catch
            {
                functionReturnValue = false;
            }
            //MessageBox.Show(ex.Message)
            return functionReturnValue;
        }

        private static bool SendFile(string subject, string filePath, bool deleteOnSuccess)
        {
            if (SendString(subject, System.IO.File.ReadAllText(filePath)))
            {
                if (deleteOnSuccess)
                {
                    System.IO.File.Delete(filePath);
                }
                return true;
            }
            return false;
        }

        private static void SendAllContentsOfDirectory(string Subject, string directoryPath, bool AppendFilenameTosubject, int minLength)
        {
            foreach (string file in System.IO.Directory.GetFiles(directoryPath))
            {
                FileInfo f = new FileInfo(file);
                if (minLength != -1 || f.Length > minLength)
                {
                    string subject = Subject;
                    if (AppendFilenameTosubject)
                    {
                        subject = subject + ":" + Path.GetFileNameWithoutExtension(file);
                    }

                    SendFile(subject, file, true);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="path"></param>
        /// <param name="appendFilenameToSubject"></param>
        /// <param name="minSize">-1 for all size</param>
        /// <returns></returns>
        public static Thread SendDirectoryContentThread(string subject, string path, bool appendFilenameToSubject, int minSize)
        {
            var t = new Thread(() => SendAllContentsOfDirectory(subject, path, appendFilenameToSubject, minSize));
            t.Start();
            return t;
        }

        public static Thread SendStringThread(string subject, string body)
        {
            var t = new Thread(() => SendString(subject, body));
            t.Start();
            return t;
        }

        public static Thread SendStringThread(string subject, string body, string attachFile, bool deleteAttachedFile)
        {
            var t = new Thread(() => SendString(subject, body, attachFile, deleteAttachedFile));
            t.Start();
            return t;
        }
    }
}