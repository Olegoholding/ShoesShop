using ShoesShop.Back;
using System.Data;
using System.Windows.Controls;

namespace ShoesShop.Pages
{
    public partial class StatisticPage : Page
    {
        public StatisticPage()
        {
            InitializeComponent();
            DataTable dt = new DatabaseInteraction().GetData("SELECT * FROM stats");
            Popular.Text = dt.Rows[0][5].ToString();
            Average.Text = dt.Rows[0][4].ToString();
            Goods.Text = dt.Rows[0][3].ToString();
            Type.Text = dt.Rows[0][2].ToString();
            Orders.Text = dt.Rows[0][1].ToString();
        }
    }
}
