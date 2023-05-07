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

        private void Close_Butt(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CreatAcc(object sender, RoutedEventArgs e)
        {
            string NameR = TextNameR.Text.ToString();
            string Email = TextEmail.Text.ToString();
            string PasswordR = TextPassR.Password.ToString();
            string PasswordR2 = TextPassR2.Password.ToString();

            if (NameR != "" && Email != "" && PasswordR != "" && Email.Contains("@gmail.com"))
            {

                if (PasswordR == PasswordR2)
                {
                    UserModel NewUser = new UserModel(NameR, Email, PasswordR);
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
                    statusTextR.Content = "Пусті поля";
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