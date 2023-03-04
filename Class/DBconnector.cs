using MySqlConnector;
using System;
using System.Windows;

namespace MyApp.Class
{
    internal class DBconnector
    {
        //Підкл БД
        public static string myConnectionString = @"server=localhost;user=root;password=;database=MyApp";

       /* public static bool InputCL(string gmailUser, string passUser)
        {

            MySqlConnection connection = new MySqlConnection(myConnectionString);
            connection.Open();

            //Створення запиту SQL Командами
            string query = "select count(1) from User where Gmail=@gmail and Password=@password";

            bool validUser;
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                //Вставка параметров 
                cmd.Parameters.AddWithValue("@gmail", gmailUser);
                cmd.Parameters.AddWithValue("@password", passUser);

                validUser = Convert.ToInt32(cmd.ExecuteScalar()) == 1 ? true : false;
                connection.Close();
            }
            return validUser;
        }*/

        public static int CreateCL(string gmailUser, string passUser)
        {

            MySqlConnection connection = new MySqlConnection(myConnectionString);

            string query1 = "INSERT INTO User (Id, Firstname, Lastname, Gmail, Password) VALUES (NULL, '', '', @gmailUser, @password);";
            connection.Open();

            using (MySqlCommand cmd = new MySqlCommand(query1, connection))
            {
                //Вставка параметров 
                cmd.Parameters.AddWithValue("@gmailUser", gmailUser);
                cmd.Parameters.AddWithValue("@password", passUser);

                try
                {
                    object result = cmd.ExecuteScalar();
                    connection.Close();
                    return 1;
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062) // 1062 - код дублирования ключа
                    {
                        connection.Close();
                        return 2;
                    }
                    else
                    {
                        connection.Close();
                        MessageBox.Show("Ошибка: " + ex.Message);
                        return 0;
                    }
                }
            }
        } 
    }
}
