using System;
using System.Windows;
using InformationSecurity;

namespace InforrmationSecurity
{
    public partial class RegisterWindow : Window
    {
        private readonly MainWindow _parentWindow;

        public RegisterWindow(MainWindow parentWindow)
        {
            InitializeComponent();

            _parentWindow = parentWindow;
        }

        private void RegisterWindow_OnClosed(object sender, EventArgs e)
        {
            Close();

            _parentWindow.Show();
        }
    }
}
