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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShoesShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private bool _isDarkTheme = true;
        public MainPage()
        {
            InitializeComponent();
            CurrentTime.Text = DateTime.Now.ToShortTimeString();
            ThemeComboBox.SelectedIndex = Convert.ToInt16(_isDarkTheme);
        }

        private void ThemeChanged(object sender, SelectionChangedEventArgs e)
        {
            _isDarkTheme = !_isDarkTheme;
            string currentTheme = _isDarkTheme ? "LightTheme" : "DarkTheme";

            var newTheme = (ResourceDictionary)Application.LoadComponent(new Uri($"Theme/{currentTheme}.xaml", UriKind.Relative));
            Application.Current.Resources.MergedDictionaries.RemoveAt(0);
            Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }
    }
}
