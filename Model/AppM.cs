using MyApp.Class;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace MyApp.Model
{
    public class AppM : INotifyPropertyChanged
    {
        private AppModel selectedApp;
        public ObservableCollection<AppModel> Apps { get; set; }

        public AppModel SelectedApp
        {
            get { return selectedApp; }
            set
            {
                selectedApp = value;
            }
        }

        public AppM()
        {
            Apps = new ObservableCollection<AppModel>
        {
            new AppModel {Id=1, ImagePath=@"C:\Users\ADMIN\Desktop\WPF\inst.png", Name="Instagram", Company="1" },
            new AppModel {Id=2, ImagePath=@"C:\Users\ADMIN\Desktop\WPF\Atv.png", Name="AppleTV", Company="2" },
            new AppModel { Id = 3, ImagePath = @"C:\Users\ADMIN\Desktop\WPF\Gmail.png", Name = "Gmail", Company = "3" },
            new AppModel { Id = 4, ImagePath = @"C:\Users\ADMIN\Desktop\WPF\Tik.png", Name = "Tik", Company = "4" },
            new AppModel { Id = 4, ImagePath = @"C:\Users\ADMIN\Desktop\WPF\Tik.png", Name = "Tik", Company = "4" },
            new AppModel { Id = 4, ImagePath = @"C:\Users\ADMIN\Desktop\WPF\Tik.png", Name = "Tik", Company = "4" },
            new AppModel { Id = 4, ImagePath = @"C:\Users\ADMIN\Desktop\WPF\Tik.png", Name = "Tik", Company = "4" },
            new AppModel { Id = 4, ImagePath = @"C:\Users\ADMIN\Desktop\WPF\Tik.png", Name = "Tik", Company = "4" }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }


}
