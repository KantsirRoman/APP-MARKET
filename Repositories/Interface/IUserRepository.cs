using System.Collections.Generic;
using System.Net;

namespace MyApp.Model
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        int Add(UserModel userModel);
        void Edit(UserModel userModel);
        void Remove(int id);
        UserModel GetById(int id);
        UserModel GetByUsername(string username);
        IEnumerable<UserModel> GetByAll();
        
    }
}
