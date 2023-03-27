using MyApp.Model;
using MyApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyApp.View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
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

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPass.Password) && txtPass.Password.Length > 0)
                textPassword.Visibility = Visibility.Collapsed;
            else
                textPassword.Visibility = Visibility.Visible;
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPass.Focus();
        }

        private void Input(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtPass.Password) && txtEmail.Text.Contains("@gmail.com"))
            {
                string gmailUser = txtEmail.Text.ToString();
                string passUser = txtPass.Password.ToString();

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
            else
            {
                statusText.Content = "Не вірні данні";
            }
        }
    private void txtEmail_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
                textEmail.Visibility = Visibility.Collapsed;
            else
                textEmail.Visibility = Visibility.Visible;
        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

    }

}

