using MyApp.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using MyApp.Class;

namespace MyApp.View
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public ObservableCollection<AppC> Apps { get; set; }
        public Home()
        {
            InitializeComponent();
            DataContext = new AppM();
        }

        private void appList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AppC p = (AppC)appList.SelectedItem;
            MessageBox.Show(p.Name);
        }
    }
}
