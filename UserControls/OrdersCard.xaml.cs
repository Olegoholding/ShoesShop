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
    /// Логика взаимодействия для OrdersCard.xaml
    /// </summary>
    public partial class OrdersCard : UserControl
    {
        int _id;
        string _firstName;
        string _lastName;
        string _goods;
        int _count;
        int _price;

        public OrdersCard(int id, string firstName, string lastName, string goods, int count, int price)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _goods = goods;
            _count = count;
            _price = price;

            InitializeComponent();
            LoadCard();
        }

        private void LoadCard()
        {
            IdText.Text = "#" + _id.ToString();
            FioText.Text = $"{_lastName + _firstName}";
            GoodsText.Text = $"{_goods} \t x{_count}";
            PriceText.Text = _price + " руб." ;
        }
    }
}
