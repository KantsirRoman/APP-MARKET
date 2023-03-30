using MyApp.Model;
using MyApp.Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyApp.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
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

        public HomeViewModel()
        {
            IUploadPhoto GetAPP = new UploadApp();
            GetAPP.GetApp();
            Apps = new ObservableCollection<AppModel>(GetAPP.GetApp());
            /*Apps = new ObservableCollection<AppModel>
            {
            new AppModel { Id = 1, Image = @"C:\Users\ADMIN\Desktop\WPF\inst.png", Name="Instagram", Company="1" },
            new AppModel { Id = 2, Image = @"C:\Users\ADMIN\Desktop\WPF\Atv.png", Name="AppleTV", Company="2" },
            new AppModel { Id = 3, Image = @"C:\Users\ADMIN\Desktop\WPF\Gmail.png", Name = "Gmail", Company = "3" },
            new AppModel { Id = 4, Image = @"C:\Users\ADMIN\Desktop\WPF\Tik.png", Name = "Tik", Company = "4" },
            new AppModel { Id = 4, Image = @"C:\Users\ADMIN\Desktop\WPF\Tik.png", Name = "Tik", Company = "5" },
            new AppModel { Id = 4, Image = @"C:\Users\ADMIN\Desktop\WPF\Tik.png", Name = "Tik", Company = "6" },
            };*/
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }


}
