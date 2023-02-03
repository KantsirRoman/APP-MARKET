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
    }
}
