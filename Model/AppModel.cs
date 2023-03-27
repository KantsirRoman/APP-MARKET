﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

//model APP

namespace MyApp.Model
{
    public class AppModel : INotifyPropertyChanged
    {
       

        public int Id;
        public string Name;
        public string Company;
        public string About;
        public string Image;
        public AppModel()
            /*: this("Instagram", "1","about",@"C:\Users\ADMIN\Desktop\WPF\inst.png")*/
        {
        }

        public AppModel(string Name, string Company, string About, string Image)
        {
            this.Name = Name;
            this.Company = Company;
            this.About = About;
            this.Image = Image;

        }


        public string name
        {
            get { return Name; }
            set
            {
                Name = value;
                OnPropertyChanged("name");
            }
        }

        public string company
        {
            get { return Company; }
            set
            {
                Company = value;
                OnPropertyChanged("company");
            }

        }

        public string about
        {
            get { return About; }
            set
            {
                About = value;
                OnPropertyChanged("about");
            }

        }

        public string image
        {
            get { return Image; }
            set
            {
                Image = value;
                OnPropertyChanged("image");
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
