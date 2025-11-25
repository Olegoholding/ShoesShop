using ShoesShop.Back;
using ShoesShop.UserControls;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace ShoesShop.Pages
{
    public partial class DataPage : Page
    {
        string _tag;
        DatabaseInteraction db = new DatabaseInteraction();
        public DataPage(string tag)
        {
            _tag = tag;

            InitializeComponent();
            LoadCards();
        }


        private void LoadCards()
        {
            DataTable dataTable = db.GetData($"Select * from {_tag}");
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
