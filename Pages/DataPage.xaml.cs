using ShoesShop.Back;
using ShoesShop.UserControls;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace ShoesShop.Pages
{
    public partial class DataPage : Page
    {
        string Tag;
        string Uid;
        DatabaseInteraction db = new DatabaseInteraction();
        public DataPage(string tag, string uid)
        {
            InitializeComponent();
            Tag = tag;
            Uid = uid;

            LoadCards();
        }

        private void LoadCards()
        {
            DataTable dataTable = db.GetData($"Select * from ShowShoes");
            foreach (DataRow row in dataTable.Rows)
            {
                wrapPanel.Children.Add(new GoodsCard(
                    row["Изображение"].ToString(),
                    row["Название"].ToString(),
                    row["Цена"].ToString() + " руб"
                    ));
            }
        }
    }
}
