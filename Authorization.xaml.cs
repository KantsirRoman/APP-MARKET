using MyApp.Class;
using MyApp.Model;
using MyApp.Repositories;
//folders
using System;
using System.Net;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Input;


namespace MyApp
{
    public partial class MainWindow : Window
    {
        public static MainWindow WindowDrag;


        public MainWindow()
        {
            InitializeComponent();
            WindowDrag = this;
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                MainWindow.WindowDrag.DragMove();
            }

        }

        private void Input(object sender, RoutedEventArgs e)
        {
            //Загрузили фото в бд
           /* IUploadPhoto UpPh = new UploadPhoto();
            UpPh.SetUploadPhoto("");*/


            string gmailUser = String.Format(TextLog.Text);
            string passUser = TextPass.Password.ToString();

            IUserRepository userRepository = new UserRepository();
            var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(gmailUser, passUser));
            if (isValidUser)
            {
                statusText.Content = "Вхід дозволено";
                WorkingSpaceW wnd2 = new WorkingSpaceW();
                wnd2.Owner = this;
                this.Hide();
                wnd2.ShowDialog();
            }
            else
            {
                statusText.Content = "Не вірні данні";
            }
        }

        private void Input2(object sender, RoutedEventArgs e)
        {
            string gmailUser = String.Format(TextLog.Text);
            string passUser = TextPass.Password.ToString();

            /*if (DBconnector.InputCL(gmailUser, passUser))
            {
                statusText.Content = "Вхід дозволено";
                WorkingSpaceW wnd2 = new WorkingSpaceW();
                wnd2.Owner = this;
                this.Hide();
                wnd2.ShowDialog();
            }
            else
            {
                statusText.Content = "Не вірні данні";
            }*/

            /*MySqlConnection connection = new MySqlConnection(myConnectionString);
            connection.Open();

            //Створення запиту SQL Командами
            string query = "select count(1) from User where Name=@user and Password = @password";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                //Вставка параметров 
                cmd.Parameters.AddWithValue("@user", gmailUser);
                cmd.Parameters.AddWithValue("@password", passUser);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 1)
                {
                    statusText.Content = "Success";
                    connection.Close();
                    
                }
                else
                {
                    statusText.Content = "NO";
                }
            }*/


            //Вход MONGODB (json)

            /*bool next = false;
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
                next = true;
                break;
            }
            else
            {
                statusText.Content = "Wrong Password";
            }
            }
            if (next)
            {
                WorkingSpaceW wnd2 = new WorkingSpaceW();
                wnd2.Owner = this;
                this.Hide();
                wnd2.ShowDialog();
            }*/
        }

        private void CreatAcc(object sender, RoutedEventArgs e)
        {
            string LoginR = TextLogR.Text.ToString();
            string Email = TextEmail.Text.ToString();
            string PasswordR = TextPassR.Password.ToString();
            string PasswordR2 = TextPassR2.Password.ToString();

            if (LoginR != "" && Email != "" && PasswordR != "" && Email.Contains("@gmail.com"))
            {

                if (PasswordR == PasswordR2)
                {
                    UserModel NewUser = new UserModel(Email, PasswordR);
                    IUserRepository userRepository = new UserRepository();
                    switch (userRepository.Add(NewUser))
                    {
                        case 0:
                            {
                                statusTextR.Content = "Невідома помилка";
                            }
                            break;
                        case 1:
                            {
                                statusTextR.Content = "Аккаунт створено";
                            }
                            break;
                        case 2:
                            {
                                statusTextR.Content = "Аккаунт вже існує";
                            }
                            break;

                        default:
                            break;
                    }
                    /*User nuser = new User(LoginR, Email, PasswordR);
                        collectionUsers.InsertOne(nuser);
                        statusTextR.Content = $"Аккаунт {LoginR} создан";*/
                }
                else
                {
                    statusTextR.Content = "Пароль не совпадает";
                }

            }
            else
            {
                if (Email == "" || PasswordR == "")
                {
                    statusTextR.Content = "Пустые поля";
                }
                else if (!Email.Contains("@gmail.com"))
                {
                    statusTextR.Content = "Не коректно введена пошта";
                }
            }
            /*var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("LoginApp");
            IMongoCollection<User> collectionUsers = database.GetCollection<User>("Users");
            List<User> usersdataR = collectionUsers.Find(new BsonDocument()).ToList();

            string LoginR = TextLogR.Text.ToString();
            string Email = TextEmail.Text.ToString();
            string PasswordR = TextPassR.Password.ToString();
            string PasswordR2 = TextPassR2.Password.ToString();

        if (LoginR != "" && Email != "" && PasswordR != "" && Email.Contains("@gmail.com"))
        {
            bool goodjob = false;
            foreach (var user in usersdataR)
            {
                if (LoginR == user.name)
                {
                    statusTextR.Content = $"Акк {user.name} уже существует";
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
                statusTextR.Content = "Пустые поля";
            }
        }*/
        }

        private void ButtonClose(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

            /*Window1 wnd2 = new Window1();
            wnd2.Owner = this;
            this.Hide();
            wnd2.ShowDialog();*/

            /*MainWindow.Hide();
            Window f2 = new Window1();
            f2.ShowDialog();
            fhis.Show();*/
        }


    }
}

