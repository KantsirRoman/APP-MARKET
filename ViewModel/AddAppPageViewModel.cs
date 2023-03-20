using MyApp.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyApp.ViewModel
{
    internal class AddAppPageViewModel : INotifyPropertyChanged
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
        //**********************************************************************

        private AppModel _AppModel;

        public AppModel AppModel
        {
            get
            {
                return _AppModel;
            }
            set
            {
                _AppModel = value;
            }
        }
        public AddAppPageViewModel()
        {
        }

        public AddAppPageViewModel(AppModel app)
        {
            _AppModel = app;
        }

        public string Name
        {
            get { return AppModel.Name; }
            set
            {
                _AppModel.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Company
        {
            get { return _AppModel.Company; }
            set
            {
                _AppModel.Company = value;
                OnPropertyChanged("Company");
            }

        }
        
        public string About
        {
            get { return _AppModel.About; }
            set
            {
                _AppModel.About = value;
                OnPropertyChanged("About");
            }

        }

        public string Image
        {
            get { return _AppModel.Image; }
            set
            {
                _AppModel.Image = value;
                OnPropertyChanged("Image");
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
