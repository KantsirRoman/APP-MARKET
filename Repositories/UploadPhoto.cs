using MongoDB.Driver.Core.Configuration;
using MyApp.Model;
using MySqlConnector;
using System;
using System.Collections;
using System.IO;
using System.Windows.Media.Imaging;

namespace MyApp.Repositories
{
    public class UploadPhoto : RepositoryBase, IUploadPhoto
    {
        private byte[] byteArray;

        public void SetUploadPhoto()
        {
            var bitmap = new BitmapImage(new Uri(@"C:\Users\ADMIN\source\repos\MyApp\Images\Gmail.png", UriKind.Relative));
            var encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmap));
            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                byteArray = stream.ToArray();
            }

            using (var connection = GetConnection())
            {
                connection.Open();
                string sql = "INSERT INTO Photos (Name, Image) VALUES (@Name, @Image)";
                using (var command = new MySqlCommand(sql, connection))
                {
                    // установка параметров запроса
                    command.Parameters.AddWithValue("@Name", "MyPhoto.jpg");
                    command.Parameters.AddWithValue("@Image", byteArray); // byteArray - массив байтов изображения

                    // выполнение запроса
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }



        }
    }
}
