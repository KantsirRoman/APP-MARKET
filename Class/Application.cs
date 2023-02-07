using System.ComponentModel;

// Класс (приложение)

namespace MyApp.Class
{
    internal class Application : INotifyPropertyChanged
    {

        public string Name
        {
            get { return Name; }
            set
            {
                Name = value;
                OnPropertyChanged("Name");
                /*if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));*/
            }
        }
        public string About {
            get { return About; }
            set
            {
                About = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("About"));
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
       public Application(string Name, string About) { 
            //this.idApp = idApp;
            this.Name = Name;
            this.About = About;
           // this.UrlApp = UrlApp;
        }


    }
}
