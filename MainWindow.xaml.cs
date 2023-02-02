using MyApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

using UserClass;
using DB;

namespace DB
{
    public class LoadDBinfo
    {
    }
}

            
namespace APP
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Input(object sender, RoutedEventArgs e)
        {
            List<User> UserDBRead()
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("LoginApp");
                IMongoCollection<User> collectionUsers = database.GetCollection<User>("Users");
                List<User> users = collectionUsers.Find(new BsonDocument()).ToList();
                return users;
            }
            List<User> usersdata = UserDBRead();
            foreach (var user in usersdata)
            {
            if (TextLog.Text == user.name && TextPass.Password.ToString() == user.password)
            {
                statusText.Content = user.name;
            }
            else
            {
                statusText.Content = "Wrong Password";
            }
            }
        }
        
        private void CreatAcc(object sender, RoutedEventArgs e)
        {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("LoginApp");
                IMongoCollection<User> collectionUsers = database.GetCollection<User>("Users");
                List<User> usersdataR = collectionUsers.Find(new BsonDocument()).ToList();
                
                string LoginR = TextLogR.Text.ToString();
                string Email = TextEmail.Text.ToString();
                string PasswordR = TextPassR.Password.ToString();
                string PasswordR2 = TextPassR2.Password.ToString();

            if (LoginR != "" && Email != "" && PasswordR != "")
            {
                bool goodjob = false;
                foreach (var user in usersdataR)
                {
                    if (LoginR == user.name)
                    {
                        statusTextR.Content = $"{user.name} Уже существует";
                        goodjob = false;
                        break;
                    }
                    else
                    {
                        goodjob = true;
                    }
                }
                if (goodjob)
                {
                    if (PasswordR == PasswordR2)
                    {   
                        User nuser = new User(LoginR, Email, PasswordR);
                        collectionUsers.InsertOne(nuser);
                        statusTextR.Content = $"Аккаунт {LoginR} создан";
                    }
                    else
                    {
                        statusTextR.Content = "Пароль не совпадает";
                    }
                }
            }
            else
            { if (statusTextR.ToString() != "Пароль не совпадает")
                {
                    statusTextR.Content = "Пустые ячейки или юзур cуществует";
                }
            }
        }

    }
}

