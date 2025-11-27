using System.Windows.Controls;

namespace ShoesShop.UserControls
{
    public partial class GoodsType : UserControl
    {
        public GoodsType(int id, string name)
        {
            InitializeComponent();

            IdText.Text = "#" + id.ToString();
            NameText.Text = name;
        }
    }
}
