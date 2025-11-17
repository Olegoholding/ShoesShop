using System.Text;
using ShoesShop.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShoesShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainPage mainPage = new();
        RadioButton[] radioButtons;


        public MainWindow()
        {
            InitializeComponent();

            radioButtons = new[] { SizesButton, GoodsButton, OrdersButton };

            Frame.Content = mainPage;
        }
        private void ToMainPage(object sender, MouseButtonEventArgs e)
        {
            foreach (RadioButton radioButton in radioButtons)
                radioButton.IsChecked = false;          

            Frame.Content = mainPage;
        }

        private void SizesButton_Checked(object sender, RoutedEventArgs e)
        {
            //Если что эту штуку вызывает radiobutton, зная
            //твою любовь к максимальному сокращению оставляю 
            //тебе этот вариант

            DataPage page = new();
            Frame.Content = page;
        }
    }
}