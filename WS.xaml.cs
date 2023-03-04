using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using MyApp.View;

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
            //frame.Navigate("/View/Home.xaml");

            //frame.Navigate(@"{System.Windows.Controls.Frame: View/Home.xaml}".Navlink);
            //frame.Navigate(@"MyAPP/View/Home.xaml");
            // sidebar.SelectedItem as NavButton = "StartP";
        }
        /*private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {   
            frame.Navigate(new Home());
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new UserP());

        }*/
        private void sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selected = sidebar.SelectedItem as NavButton;

            frame.Navigate(selected.Navlink);

        }
        
    }
}
