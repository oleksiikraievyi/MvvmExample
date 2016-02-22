using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows;
using InformationSecurity.FileSystem;
using InforrmationSecurity.Annotations;

namespace InformationSecurity.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private readonly Timer _timer;
        
        public UserViewModel()
        {
            _timer = new Timer
            {
                Interval = new TimeSpan(0, 0, 15).Seconds
            };

            _timer.Elapsed += Tick;
            _timer.Start();
        }

        private void Tick(object sender, EventArgs eventArgs)
        {
            MessageBox.Show("Alert!");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}