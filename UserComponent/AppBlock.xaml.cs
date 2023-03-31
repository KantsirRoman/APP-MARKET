using System.Windows.Controls;

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
