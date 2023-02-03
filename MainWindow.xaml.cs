using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using UserClass;


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
            bool next = false;
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
            }
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

