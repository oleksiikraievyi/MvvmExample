using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using InformationSecurity.Dal.Model;

namespace InformationSecurity.Dal.Dal
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly UserContext _context;
        private bool _disposed;

        public UserRepository()
        {
            _context = new UserContext();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(@user => @user.Id.Equals(userId));
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(@user => @user.Username.Equals(username));
        }

        public void InsertUser(User user)
        {
            _context.Users.Add(user);
        }

        public void DeleteUser(int userId)
        {
            _context.Users.Remove(GetUserById(userId));
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose(); ;
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}