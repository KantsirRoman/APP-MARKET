using MongoDB.Driver.Core.Configuration;
using MyApp.Model;
using MySqlConnector;
using System;
using System.Collections;
using System.IO;
using System.Windows.Media.Imaging;

namespace MyApp.Repositories
{
    public class UploadApp : RepositoryBase, IUploadPhoto
    {
        private byte[] byteArray;

        public void SetUploadApp(AppModel app)
        {
            var bitmap = new BitmapImage(new Uri(app.Image, UriKind.Relative));
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
                string sql = "INSERT INTO AllApp (Id, Name,Company, About, Image) VALUES (NULL,@Name,@Company,@About, @Image)";
                
                using (var command = new MySqlCommand(sql, connection))
                {
                    // установка параметров запроса
                    command.Parameters.AddWithValue("@Name", app.Name);
                    command.Parameters.AddWithValue("@Company", app.Company);
                    command.Parameters.AddWithValue("@About", app.About);
                    command.Parameters.AddWithValue("@Image", byteArray); // byteArray - массив байтов изображения

                    // выполнение запроса
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }



        }
    }
}
