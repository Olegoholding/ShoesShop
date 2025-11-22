using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ShoesShop
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Window
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if(!ValidationComplete())
                return;

            MainWindow mainWindow = new MainWindow();
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
            this.Close();
        }

        private bool ValidationComplete()
        {
            bool loginValid = !string.IsNullOrEmpty(LoginTextBox.Text);
            bool passValid = !string.IsNullOrEmpty(PasswordTextBox.Text);

            LoginValidation.Visibility = loginValid ? Visibility.Collapsed : Visibility.Visible;
            PasswordValidation.Visibility = passValid ? Visibility.Collapsed : Visibility.Visible;

            return loginValid && passValid;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
