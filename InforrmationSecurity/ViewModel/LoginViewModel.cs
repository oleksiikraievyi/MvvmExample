using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using InformationSecurity.Annotations;
using InformationSecurity.Bal;
using InformationSecurity.FileSystem;
using InforrmationSecurity;

namespace InformationSecurity.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private int _captchaAnswer;

        public string Username { get; set; }

        public string Password { get; set; }

        private string _captcha;

        public string Captcha
        {
            get { return _captcha; }
            set
            {
                _captcha = value;
                OnPropertyChanged(nameof(Captcha));
            }
        }

        public string CaptchaAnswer { get; set; }

        public Command.Command LoginCommand { get; set; }

        public UserManager UserManager { get; } = UserManager.Instance;

        public FileSystemManager FileSysManager { get; } = FileSystemManager.Instance;

        public LoginViewModel()
        {
            LoginCommand = new Command.Command(_ => {Login();});

            GenerateCaptcha();
        }

        private void Login()
        {
            if (string.IsNullOrEmpty(Username))
            {
                MessageBox.Show("User name field is empty");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Password field is empty");
                return;
            }

            int captchaAnswer;
            if (!int.TryParse(CaptchaAnswer, out captchaAnswer))
            {
                MessageBox.Show("Invalid input in captcha field");
                return;
            }

            if (captchaAnswer != _captchaAnswer)
            {
                MessageBox.Show("Captcha is wrong");

                GenerateCaptcha();
                return;
            }

            if (UserManager.Login(Username, Password))
            {
                MessageBox.Show("Login successful");
            }
            else
            {
                MessageBox.Show("No user found in database");
                return;
            }

            if (UserManager.CurrentUser.IsAdmin)
            {
                new AdminWindow().Show();
            }
            else
            {
                new UserWindow().Show();
            }
        }

        private void GenerateCaptcha()
        {
            var x = new Random().Next(0, 2);
            Captcha = $"exp(10*{x})";
            _captchaAnswer = (int) Math.Exp(10*x);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}