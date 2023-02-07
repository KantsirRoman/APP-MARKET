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
                OnPropertyChanged("SelectedPhone");
            }
        }

        public ApplicationViewModel()
        {
            ApplicationS = new ObservableCollection<Application>
            {
                new Application { Name="123", About="123"},
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
