using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MyApp.Class;

namespace MyApp.ViewModel
{
    public class AppVM : INotifyPropertyChanged
    {
        private AppModel application;

        public AppVM(AppModel p)
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
