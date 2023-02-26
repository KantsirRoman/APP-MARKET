using MyApp.Class;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyApp.ViewModel
{
    /*public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Application application;

        public ApplicationViewModel(Application p)
        {
            application = p;
        }

        public string Name
        {
            get { return application.Name; }
            set
            {
                application.Name = value;
                OnPropertyChanged("name");
            }
        }
        
        public string About
        {
            get { return application.About; }
            set
            {
                application.About = value;
                OnPropertyChanged("About");
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
    
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }  */ 
} 

