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
        private AppC selectedApp;
        public ObservableCollection<AppC> Apps { get; set; }

        public AppC SelectedApp
        {
            get { return selectedApp; }
            set
            {
                selectedApp = value;
            }
        }

        public AppM()
        {
            Apps = new ObservableCollection<AppC>
        {
            new AppC {Id=1, ImagePath=@"C:\Users\ADMIN\Desktop\inst.png", Name="Instagram", Company="" },
            new AppC {Id=2, ImagePath=@"C:\Users\ADMIN\Desktop\Atv.png", Name="AppleTV", Company="" },
            new AppC { Id = 3, ImagePath = @"C:\Users\ADMIN\Desktop\Gmail.png", Name = "Gmail", Company = "" },
            new AppC { Id = 4, ImagePath = @"C:\Users\ADMIN\Desktop\Tik.png", Name = "TikRok", Company = "" }
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
