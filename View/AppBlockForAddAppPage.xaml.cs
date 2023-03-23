using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyApp.View
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class AppBlock : UserControl
    {
        public int Id;
        public string Name;
        public string Company;
        public string About;
        public string Image;


       /* public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string name
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string company
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }

        }

        public string about
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }

        }

        public string image
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }

        }
*/
        public AppBlock()
        {
            InitializeComponent();
        }
    }
}
