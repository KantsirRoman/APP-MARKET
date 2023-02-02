using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace UserClass
{
    class User
    {
        public ObjectId id { get; set; }
        public string name { get; set; }
        public string Email { get; set; }
        public string password { get; set; }

    public User(string name,string Email, string password)
    {
        this.name = name;
        this.Email = Email;
        this.password = password;
    }
    }

}
