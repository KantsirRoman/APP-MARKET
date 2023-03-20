using Microsoft.Win32;
using MyApp.Model;
using MyApp.Repositories;
using SharpCompress.Common;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using MyApp.ViewModel;
using System.ComponentModel;

namespace MyApp.View
{
    /// <summary>
    /// Логика взаимодействия для AddAppP.xaml
    /// </summary>
    public partial class AddAppPage : Page
    {
        private string filePath = string.Empty;
        private string fileName = string.Empty;
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
            }

        }

        private void UploadToDB(object sender, RoutedEventArgs e)
        {
            //Загрузили фото в бд
            if (filePath == string.Empty) {
                MessageBox.Show("Додайте фото");
            }
            else
            {
                //var editableCollectionView = itemsControl.Items as IEditableCollectionView;

                

                /*AppModel model = new AppModel();
                model.Name = "Roman";
                IUploadPhoto UpPh = new UploadApp();
                UpPh.SetUploadApp(model);*/
            }
        }

        
    }
}
