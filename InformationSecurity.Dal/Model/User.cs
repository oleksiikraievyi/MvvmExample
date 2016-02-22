using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace InformationSecurity.Dal.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string AvailableDirectories { get; set; }
        public List<string> AvailableDirectoriesList { get; set; }

        public User() { }

        public User(string username, string password, bool isAdmin)
        {
            Username = username;
            Password = password;
            IsAdmin = isAdmin;

            AvailableDirectories = $"{Username},";
            AvailableDirectoriesList = AvailableDirectories.Split(new []{ ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}