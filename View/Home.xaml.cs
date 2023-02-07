using MyApp.Model;
using System.Windows.Controls;

namespace MyApp.View
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();
        }
    }
}
