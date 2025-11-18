using ShoesShop.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ShoesShop
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Frame.Content = new MainPage();
        }
        private void SizesButton_Checked(object sender, RoutedEventArgs e) => Frame.Content = new DataPage(((RadioButton)sender).Tag.ToString(), ((RadioButton)sender).Uid);
        private void ToMainPage(object sender, MouseButtonEventArgs e)
        {
            Grid.Children.OfType<RadioButton>().ToList().ForEach(rb => rb.IsChecked = false);
            Frame.Content = new MainPage();
        }
    }
}