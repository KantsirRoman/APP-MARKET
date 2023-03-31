using Microsoft.Win32;
using MyApp.Model;
using MyApp.Repositories;
using SharpCompress.Common;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using MyApp.ViewModel;
using System.ComponentModel;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace MyApp.View
{

    public partial class AddAppPage : Page
    {
        private string filePath = string.Empty;
        private string fileName = string.Empty;
        private byte[] byteArray;
        public AddAppPage()
        {
            InitializeComponent();
            DataContext = new AddAppPageViewModel();
        }

        private void UploadPhoto(object sender, RoutedEventArgs e)
        {
            var fileContent = string.Empty;


            OpenFileDialog dialog = new OpenFileDialog();


            dialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";


            dialog.InitialDirectory = "c:\\";

            if (dialog.ShowDialog() == true)
            {
                //Get the path of specified file
                filePath = dialog.FileName;
                fileName = Path.GetFileName(dialog.FileName);  //с расширением

                //Read the contents of the file into a stream
                var fileStream = dialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
                MessageBox.Show(filePath);

                byteArray = ImageToByteArray(filePath);


                 BitmapImage bitmap = new BitmapImage();
                 bitmap.BeginInit();
                 bitmap.UriSource = new Uri(filePath);
                 bitmap.EndInit();

                 PhotoInPreview.Source = bitmap;

            }
            
        }
        public byte[] ImageToByteArray(string filePath)
        {
            byte[] byteArray;

            BitmapImage bitmap = new BitmapImage(new Uri(filePath));
            /*bitmap.BeginInit();
            bitmap.UriSource = new Uri(filePath);
            bitmap.EndInit();*/

            using (MemoryStream stream = new MemoryStream())
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmap));
                encoder.Save(stream);
                byteArray = stream.ToArray();
            }

            return byteArray;
        }

        private void UploadToDB(object sender, RoutedEventArgs e)
        {
            //Загрузили фото в бд
            if (filePath == string.Empty)
            {
                MessageBox.Show("Додайте фото");
            }
            else
            {
                string Name = nameInput.Text.ToString();
                string Company = companyInput.Text.ToString();
                string About = aboutInput.Text.ToString();

                if (Name != string.Empty && Company != string.Empty && About != string.Empty)
                {
                    AppModel newApp = new AppModel(Name, Company, About, byteArray);
                    IUploadPhoto UpPh = new UploadApp();
                    UpPh.SetUploadApp(newApp);
                    MessageBox.Show("Додано");
                }
                else
                {
                    MessageBox.Show("Пусті поля");
                }
              }
        }

        private void Block_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {

        }
    }
}
