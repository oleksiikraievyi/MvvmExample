using System.Collections.Generic;
using InformationSecurity.Dal.Model;

namespace InformationSecurity.Dal.Dal
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int userId);
        User GetUserByUsername(string username);
        void InsertUser(User user);
        void DeleteUser(int userId);
        void UpdateUser(User user);
        void Save();
    }
}