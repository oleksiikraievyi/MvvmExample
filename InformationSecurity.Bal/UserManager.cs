using InformationSecurity.Dal.Dal;
using InformationSecurity.Dal.Model;
using InformationSecurity.FileSystem;

namespace InformationSecurity.Bal
{
    public class UserManager
    {
        private static UserManager _userManager;

        private readonly UserRepository _userRepository;

        private UserManager()
        {
            _userRepository = new UserRepository();
        }

        public static UserManager Instance => _userManager ?? (_userManager = new UserManager());

        public User CurrentUser { get; set; }

        public bool Login(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                return false;
            }

            if (!user.Password.Equals(password))
            {
                return false;
            }

            CurrentUser = user;
            return true;
        }

        public void Register(string username, string password, bool isAdmin)
        {
            var user = new User(username, password, false);

            foreach (var dir in user.AvailableDirectoriesList)
            {
                FileSystemManager.Instance.CreateDirectory(dir);
                FileSystemManager.Instance.AddUserPermissionToDirectory(dir, user.Username);
            }

            FileSystemManager.Instance.Save();

            _userRepository.InsertUser(user);
            _userRepository.Save();
        }
    }
}