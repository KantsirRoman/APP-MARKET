using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Model
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserModel()
        {
        }

        public UserModel(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }
        public UserModel(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}
