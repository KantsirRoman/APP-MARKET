using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MyApp.Class;

namespace MyApp.Model
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Application selectedApp;
        public ObservableCollection<Application> ApplicationS { get; set; }

        public Application SelectedApp
        {
            get { return selectedApp; }
            set
            {
                selectedApp = value;
                OnPropertyChanged("SelectedApp");
            }
        }

        public ApplicationViewModel()
        {
            ApplicationS = new ObservableCollection<Application>
            {
                new Application { Name="TikTok", About="China"},
                new Application { Name="Instagram", About="USA"},
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
