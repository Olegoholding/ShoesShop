using ShoesShop.Back;
using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class RegistrationPage : Window
    {
        public RegistrationPage() => InitializeComponent();

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DatabaseInteraction().GetData(@$"SELECT * FROM Пользователи WHERE 
                Логин = '{LoginTextBox.Text.Trim()}' and 
                Пароль = '{PasswordTextBox.Text.Trim()}'; ");
            if(dt.Rows.Count == 1 )
            {
                LoginValidation.Visibility = PasswordValidation.Visibility = Visibility.Collapsed;
                new MainWindow().Show();
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка, проверьте введённые данные");
            }
        }
    }
}
