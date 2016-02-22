using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using InformationSecurity.Bal;
using InforrmationSecurity.Annotations;

namespace InformationSecurity.ViewModel
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private string _username;

        public string Username
        {
            get { return _username;  }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public Command.Command RegisterCommand { get; set; }

        public UserManager UserManager => UserManager.Instance;

        public RegisterViewModel()
        {
            RegisterCommand = new Command.Command(_ => Register());
        }

        private void Register()
        {
            UserManager.Register(Username, Password, false);

            MessageBox.Show("Registration successful");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}