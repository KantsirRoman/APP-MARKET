using System.Windows;
using System.Windows.Controls;
using System.Net;
using System.ComponentModel;
using System;
using System.IO;
using System.Threading.Tasks;

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
            DownloadFile(@"https://github.com/pbatard/rufus/releases/download/v3.21/rufus-3.21.exe");
           
        }

        public void DownloadFile(string remoteUri)
        {
           // string FilePath = Directory.GetCurrentDirectory() + "/tepdownload/" + Path.GetFileName(remoteUri); // path where download file to be saved, with filename, here I have taken file name from supplied remote url
            string FilePath = @"C:\Users\ADMIN\Desktop\" + Path.GetFileName(remoteUri); // path where download file to be saved, with filename, here I have taken file name from supplied remote url
            using (WebClient client = new WebClient())
            {
                try
                {
                    if (!Directory.Exists("tepdownload"))
                    {
                        Directory.CreateDirectory("tepdownload");
                    }
                    Uri uri = new Uri(remoteUri);
                    client.Credentials = new NetworkCredential("username", "password");    //password username of your file server eg. ftp username and password
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed); //delegate method, which will be called after file download has been complete.

                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged); //delegate method for progress notification handler.

                    client.DownloadFileAsync(uri, FilePath);   // uri is the remote url where filed needs to be downloaded, and FilePath is the location where file to be saved
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
       

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            PrBar.Value = e.ProgressPercentage;
            loadbox.Content = $"Завантажено: {((double)e.BytesReceived/1048576).ToString("0.00 МБ")}";
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
    