using MyApp.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using MyApp.ViewModel;
using MyApp.UserComponent;
using System;

namespace MyApp.View
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public ObservableCollection<AppModel> Apps { get; set; }
        public Home()
        {
            InitializeComponent();
            DataContext = new HomeViewModel();
        }

        private void appList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AppModel p = (AppModel)appList.SelectedItem;
            //MessageBox.Show(p.Name);
            //MessageBox.Show(p.Name + Environment.NewLine + p.company + Environment.NewLine + p.about);
            CustomDialog dialog = new CustomDialog(p.Name, p.company, p.about, p.image);
            dialog.ShowDialog();
            /*UserDialog dialog = new UserDialog();
            dialog.DataContext = new { Message1 = "First message", Message2 = "Second message", Message3 = "Third message" };
            dialog.ShowDialog();*/
        }
    }
}
