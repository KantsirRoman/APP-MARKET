using MyApp.Model;
using MyApp.Repositories;
using System.Net;
using System;
using System.Windows;
using System.Windows.Input;

namespace MyApp.View
{

    public partial class RegisterWindow : Window
    {

        public static RegisterWindow WindowDrag;
        public RegisterWindow()
        {
            InitializeComponent();
            WindowDrag = this;
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

        }
        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
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

        private void InputBool(object sender, RoutedEventArgs e)
        {
            
                LoginWindow wnd2 = new LoginWindow();
                wnd2.Owner = this;
                this.Hide();
                wnd2.ShowDialog();
        }
    }
}