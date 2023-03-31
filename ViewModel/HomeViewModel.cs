using MyApp.Model;
using MyApp.Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

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
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }


}
