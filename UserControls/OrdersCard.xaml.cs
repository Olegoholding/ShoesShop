using System.Windows.Controls;

namespace ShoesShop.UserControls
{
    public partial class OrdersCard : UserControl
    {

        public OrdersCard(int id, string fio, string goods, string count, int price)
        {
            InitializeComponent();
            IdText.Text = "#" + id.ToString();
            NameText.Text = fio;
            GoodsText.Text = $"{goods} \t x{count}";
            PriceText.Text = price + " руб.";
        }
    }
}
