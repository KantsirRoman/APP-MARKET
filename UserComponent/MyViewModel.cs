using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.UserComponent
{
    public class MyViewModel
    {
        public byte[] ImageSource { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public string Text4 { get; set; }

        public MyViewModel(string str1, string str2 ,string str3, byte[] img, string str4) {
            Text1 = str1;
            Text2 = str2;
            Text3 = str3;
            Text4 = str4;
            ImageSource = img;
        }
    }

}
