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

namespace ShoesShop.UserControls
{
    /// <summary>
    /// Логика взаимодействия для GoodsCard.xaml
    /// </summary>
    public partial class GoodsCard : UserControl
    {
        string _image;
        string _name;
        string _price;

        public GoodsCard(string image, string name, string price)
        {
            _image = image;
            _name = name;
            _price = price;

            InitializeComponent();
            LoadCard();
        }

        private void LoadCard()
        {
            ImageBox.Source = new BitmapImage(new Uri(_image));
            NameText.Text = _name;
            PriceText.Text = _price;
        }
    }
}
