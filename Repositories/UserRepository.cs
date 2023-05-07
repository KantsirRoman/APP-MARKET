using MyApp.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Windows;

namespace MyApp.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public int Add(UserModel userModel)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO User (Id, Name, Gmail, Password) VALUES (NULL, @name, @gmailUser, @password);";
                command.Parameters.Add("@name", (MySqlDbType)SqlDbType.NVarChar).Value = userModel.Name;
                command.Parameters.Add("@gmailUser", (MySqlDbType)SqlDbType.NVarChar).Value = userModel.Email;
                command.Parameters.Add("@password", (MySqlDbType)SqlDbType.NVarChar).Value = userModel.Password;

                try
                {
                    object result = command.ExecuteScalar();
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

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select count(1) from User where Gmail=@gmail and Password=@password";
                command.Parameters.Add("@gmail", (MySqlDbType)SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@password", (MySqlDbType)SqlDbType.NVarChar).Value = credential.Password;
                validUser = Convert.ToInt32(command.ExecuteScalar()) == 1 ? true : false;
            }
            return validUser;
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }
        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }
        public UserModel GetByUsername(string UserGmail)
        {
            UserModel user = null;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select from User where Gamil=@Gmail";
                command.Parameters.Add("@Gmail", (MySqlDbType)SqlDbType.NVarChar).Value = UserGmail;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader[0].ToString(),
                            Name = reader[1].ToString(),
                            Email = reader[2].ToString(),
                            Password = string.Empty,
                        };
                    }
                }
            }
            return user;
        }
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
