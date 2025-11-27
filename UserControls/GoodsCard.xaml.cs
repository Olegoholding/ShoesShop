using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace ShoesShop.UserControls
{
    public partial class GoodsCard : UserControl
    {
        public GoodsCard(string image, string name, string price)
        {
            InitializeComponent();
            ImageBox.Source = new BitmapImage(new Uri(image));
            NameText.Text = name;
            PriceText.Text = price;
        }
    }
}
