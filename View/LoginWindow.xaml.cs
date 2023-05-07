using MyApp.Model;
using MyApp.Repositories;
using System.Net;
using System;
using System.Windows;
using System.Windows.Input;

namespace MyApp.View
{

    public partial class LoginWindow : Window
    {
        public static LoginWindow WindowDrag;
        public LoginWindow()
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

        private void SignUp(object sender, RoutedEventArgs e)
        {
            RegisterWindow wnd2 = new RegisterWindow();
            wnd2.Owner = this;
            this.Hide();
            wnd2.ShowDialog();
        }

    }
}

