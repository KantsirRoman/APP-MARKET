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
        }
        private void sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selected = sidebar.SelectedItem as NavButton;

            frame.Navigate(selected.Navlink);

        }
        
    }
}
