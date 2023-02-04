using System;
using System.Windows;
using MyApp;

namespace MyApp.View
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
            frame.Navigate(new UserP());
        }
    }
}
