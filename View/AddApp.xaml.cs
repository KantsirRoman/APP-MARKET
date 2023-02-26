using System.Windows;
using System.Windows.Controls;
using System.Net;
using System.ComponentModel;
using System;

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
            Download();
        }
        public void Download()
        {
            string URL = "https://github.com/KantsirRoman/Sticker/raw/main/rufus-3.21.exe";
            WebClient dawn = new WebClient();
            dawn.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            dawn.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            dawn.DownloadFileAsync(new Uri(URL), @"C:\Users\ADMIN\Desktop\appp\F.exe");
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
                MessageBox.Show("Access");
            }
        }
    }
}
