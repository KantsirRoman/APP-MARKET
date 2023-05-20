using MongoDB.Driver.Core.Configuration;
using MyApp.Model;
using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace MyApp.Repositories
{
    public class AppRepository : RepositoryBase, IAppRepository
    {

        public void SetUploadApp(AppModel app)
        {
            try
            {


                using (var connection = GetConnection())
                {
                    connection.Open();
                    string sql = "INSERT INTO AllApp (Id, Name,Company, About, Image,UrlExe) VALUES (NULL,@Name,@Company,@About, @Image,@UrlExe)";

                    using (var command = new MySqlCommand(sql, connection))
                    {
                        // установка параметров запроса
                        command.Parameters.AddWithValue("@Name", app.Name);
                        command.Parameters.AddWithValue("@Company", app.Company);
                        command.Parameters.AddWithValue("@About", app.About);
                        command.Parameters.AddWithValue("@Image", app.Image); // byteArray - массив байтов изображения
                        command.Parameters.AddWithValue("@About", app.UrlExe);

                        // выполнение запроса
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

            }
            catch (MySqlException ex)
            {
                if (ex.Number == 0)
                {
                    Console.WriteLine("Unable to connect to the database.");
                }
                else
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }



        }

        public List<AppModel> GetApp()
        {
            List<AppModel> myDataList = new List<AppModel>();
            try
            {

                using (var connection = GetConnection())
                {
                    connection.Open();
                    string sql = "SELECT Id, Name,Company, About, UrlExe, Image FROM AllApp";

                    using (var command = new MySqlCommand(sql, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string company = reader.GetString(2);
                                string about = reader.GetString(3);
                                string urlexe = reader.GetString(4);
                                byte[] imageBytes = new byte[reader.GetBytes(5, 0, null, 0, int.MaxValue)];
                                reader.GetBytes(5, 0, imageBytes, 0, imageBytes.Length);


                                AppModel retApp = new AppModel { Id = id, Name = name, Company = company, About = about, Image = imageBytes, UrlExe = urlexe, };
                                myDataList.Add(retApp);

                            }
                        }
                        connection.Close();
                    }

                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 0)
                {
                    Console.WriteLine("Unable to connect to the database.");
                }
                else
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return myDataList;
        }
    }
}