using MyApp.Class;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyApp.ViewModel
{
    public class AppVM_old : INotifyPropertyChanged
    {
        private AppModel application;

        public AppVM_old(AppModel p)
        {
            application = p;
        }

        public string Name
        {
            get { return application.Name; }
            set
            {
                application.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Company
        {
            get { return application.Company; }
            set
            {
                application.Company = value;
                OnPropertyChanged("Company");
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
