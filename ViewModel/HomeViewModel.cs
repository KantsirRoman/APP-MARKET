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
       /* private string name;
        private string company;
        private string about;
        private byte[] image;*/

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
            IAppRepository GetAPP = new AppRepository();
            Apps = new ObservableCollection<AppModel>(GetAPP.GetApp());
            
        }

        /*public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Company
        {
            get { return company; }
            set
            {
                company = value;
                OnPropertyChanged(nameof(Company));
            }
        }

        public string About
        {
            get { return about; }
            set
            {
                about = value;
                OnPropertyChanged(nameof(About));
            }
        }

        public byte[] Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
*/

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }


}
