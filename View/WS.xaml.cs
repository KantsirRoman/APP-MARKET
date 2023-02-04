using MyApp.View;
using System;
using System.Windows;

namespace MyApp
{
    public partial class WorkingSpaceW : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        public WorkingSpaceW()
        {
            InitializeComponent();
        }
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {   
            frame.Navigate(new Home());
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new User());
        }
    }
}
