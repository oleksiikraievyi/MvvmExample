using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using InformationSecurity.FileSystem;
using InforrmationSecurity.Annotations;

namespace InformationSecurity.ViewModel
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Folders { get; set; }

        private FileSystemManager FileSysManager { get; } = FileSystemManager.Instance;

        public AdminViewModel()
        {
            Folders = new ObservableCollection<string>(FileSysManager.Directories.Select(@dir => @dir.Name));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}