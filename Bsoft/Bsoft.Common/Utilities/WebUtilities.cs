using System;
using System.IO;
using System.Net;

namespace Bsoft.Web
{
    public delegate void BytesDownloadedEventHandler(ByteArgs e);

    public class ByteArgs : EventArgs
    {
        private int _downloaded;
        private int _total;

        public int downloaded
        {
            get
            {
                return _downloaded;
            }
            set
            {
                _downloaded = value;
            }
        }

        public int total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
            }
        }
    }

    public class WebUtilities
    {
        public static event BytesDownloadedEventHandler bytesDownloaded;

        public static bool DownloadFromWeb(string URL, string targetFolder)
        {
            byte[] downloadedData;
            downloadedData = new byte[0];
            //open a data stream from the supplied URL
            WebRequest webReq = WebRequest.Create(URL);
            WebResponse webResponse = webReq.GetResponse();
            Stream dataStream = webResponse.GetResponseStream();
            //Download the data in chuncks
            byte[] dataBuffer = new byte[1024];
            //Get the total size of the download
            int dataLength = (int)webResponse.ContentLength;
            //lets declare our downloaded bytes event args
            ByteArgs byteArgs = new ByteArgs();
            byteArgs.downloaded = 0;
            byteArgs.total = dataLength;
            //we need to test for a null as if an event is not consumed we will get an exception
            if (bytesDownloaded != null) bytesDownloaded(byteArgs);
            //Download the data
            MemoryStream memoryStream = new MemoryStream();
            while (true)
            {
                //Let's try and read the data
                int bytesFromStream = dataStream.Read(dataBuffer, 0, dataBuffer.Length);
                if (bytesFromStream == 0)
                {
                    byteArgs.downloaded = dataLength;
                    byteArgs.total = dataLength;
                    if (bytesDownloaded != null) bytesDownloaded(byteArgs);
                    //Download complete
                    break;
                }
                else
                {
                    //Write the downloaded data
                    memoryStream.Write(dataBuffer, 0, bytesFromStream);
                    byteArgs.downloaded = bytesFromStream;
                    byteArgs.total = dataLength;
                    if (bytesDownloaded != null) bytesDownloaded(byteArgs);
                }
            }
            //Convert the downloaded stream to a byte array
            downloadedData = memoryStream.ToArray();
            //Release resources
            dataStream.Close();
            memoryStream.Close();
            //Write bytes to the specified file
            string file = URL.Substring(URL.LastIndexOf('/') + 1);

            FileStream newFile = new FileStream(targetFolder + file, FileMode.Create);
            newFile.Write(downloadedData, 0, downloadedData.Length);
            newFile.Close();
            return true;
        }

        public static string ReadString(string URL)
        {
            WebClient client = new WebClient();
            try
            {
                return client.DownloadString(URL);
            }
            catch
            {
                throw;
            }
        }
    }
}