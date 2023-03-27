using MyApp.Model;
using MyApp.Repositories;
using System;
using System.Net;
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
            
        }

        private void ButtonClose(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


    }
}

