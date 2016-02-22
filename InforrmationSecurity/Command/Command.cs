using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Effects;

namespace InformationSecurity.Command
{
    public class Command : ICommand
    {
        public Action<object> ExecuteDelegate { get; set; }
        public Predicate<object> CanExecuteDelegate { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public Command(Action<object> action)
        {
            ExecuteDelegate = action;
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteDelegate == null || CanExecuteDelegate(parameter);
        }

        public void Execute(object parameter)
        {
            var window = parameter as Window;

            if (window != null)
            {
                window.Effect = new BlurEffect { Radius = 4 };
            }

            ExecuteDelegate?.Invoke(parameter);

            if (window != null)
            {
                window.Effect = null;
                window.Close();
            }
        }
    }
}