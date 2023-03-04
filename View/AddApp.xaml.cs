using System.Windows;
using System.Windows.Controls;
using System.Net;
using System.ComponentModel;
using System;
using System.IO;

namespace MyApp.View
{
  
    public partial class AddApp : Page
    {

        // string OurURL = "https://drive.google.com/u/1/uc?id=1IvvRGN4DwHr2unkmgtDCHys2pa_dhMgT&export=download";
        public AddApp()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Download(@"https://telegram.org/dl/desktop/win64");
            DownloadStack(@"https://github.com/pbatard/rufus/releases/download/v3.21/rufus-3.21.exe");
           
        }

        public string GetNameDownloadingFile(string UrlDwnldFile) {
            int index = 0;
            int length = UrlDwnldFile.Length;
            for (int i = length - 1; i > 0; i--)
            {
                if (UrlDwnldFile[i] == '/')
                {
                    index = i + 1;
                    break;
                }
            }
            return UrlDwnldFile.Substring(index);
        }
        public void DownloadStack(string remoteUri)
        {
           // string FilePath = Directory.GetCurrentDirectory() + "/tepdownload/" + Path.GetFileName(remoteUri); // path where download file to be saved, with filename, here I have taken file name from supplied remote url
            string FilePath = @"C:\Users\ADMIN\Desktop\appp\" + Path.GetFileName(remoteUri); // path where download file to be saved, with filename, here I have taken file name from supplied remote url
            using (WebClient client = new WebClient())
            {
                try
                {
                    if (!Directory.Exists("tepdownload"))
                    {
                        Directory.CreateDirectory("tepdownload");
                    }
                    Uri uri = new Uri(remoteUri);
                    //password username of your file server eg. ftp username and password
                    client.Credentials = new NetworkCredential("username", "password");
                    //delegate method, which will be called after file download has been complete.
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    //delegate method for progress notification handler.
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    // uri is the remote url where filed needs to be downloaded, and FilePath is the location where file to be saved
                    client.DownloadFileAsync(uri, FilePath);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
       
        public void Download(string URL)
        {
           // string URL = "https://github.com/KantsirRoman/Sticker/raw/main/rufus-3.21.exe";
          //  string URL = "https://github.com/pbatard/rufus/releases/download/v3.21/rufus-3.21.exe";

            WebClient down = new WebClient();
            down.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            down.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            down.DownloadFileAsync(new Uri(URL), @"C:\Users\ADMIN\Desktop\appp\" + GetNameDownloadingFile(URL));
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //string size = (Convert.ToDouble(e.ResponseHeaders["Content-Length"])/1048576).ToString("#.#");
            PrBar.Value = e.ProgressPercentage;
            loadbox.Content = $"Загружено: {((double)e.BytesReceived/1048576).ToString("0.00 МБ")}";
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if(e.Error!= null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                loadbox.Content = "File has been downloaded.";
                MessageBox.Show("Access");
            }
        }
    }
}
