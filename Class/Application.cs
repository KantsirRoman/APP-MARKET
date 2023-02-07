using System.ComponentModel;
using System.Runtime.CompilerServices;

// Класс (приложение)

namespace MyApp.Class
{
    public class Application : INotifyPropertyChanged
    {
        private string name;
        private string about;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
                /*if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));*/
            }
        }
        public string About {
            get { return about; }
            set
            {
                about = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("About"));
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string PropertyName="")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
       /*public Application(string Name, string About) { 
            //this.idApp = idApp;
            this.Name = Name;
            this.About = About;
           // this.UrlApp = UrlApp;
        }*/


    }
}
