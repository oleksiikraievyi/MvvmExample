using System.Windows;
using InforrmationSecurity;

namespace InformationSecurity
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Register_OnClick(object sender, RoutedEventArgs e)
        {
            new RegisterWindow(this).Show();

            Visibility = Visibility.Hidden;
        }
    }
}