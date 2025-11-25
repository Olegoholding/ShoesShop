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

            wrapPanel.Children.Clear();
            _ = _tag switch
            {
                "showGoods" => LoadGoods(),
                "showUsers" => LoadUsers(),
                "showTypes" => LoadType(),
                "showOrders" => LoadOrders(),

            };
        }

        private bool LoadGoods()
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
            return true;
        }

        private bool LoadOrders()
        {
            DataTable dataTable = db.GetData($"Select * from {_tag}");
            foreach (DataRow row in dataTable.Rows)
            {
                wrapPanel.Children.Add(new OrdersCard(
                    Convert.ToInt16(row["Номер"]),
                    row["Фио"].ToString(),
                    row["Название"].ToString(),
                    Convert.ToInt16(row["Количество"].ToString()),
                    Convert.ToInt16(row["Итого"].ToString())
                    ));
            }
            return true;
        }

        private bool LoadType()
        {
            DataTable dataTable = db.GetData($"Select * from {_tag}");
            foreach (DataRow row in dataTable.Rows)
            {
                wrapPanel.Children.Add(new GoodsType(
                    Convert.ToInt16(row["Номер"]),
                    row["Название"].ToString()
                    ));
            }
            return true;
        }

        private bool LoadUsers()
        {
            DataTable dataTable = db.GetData($"Select * from {_tag}");
            foreach (DataRow row in dataTable.Rows)
            {
                wrapPanel.Children.Add(new UserCard(
                    Convert.ToInt16(row["Номер"]),
                    row["Логин"].ToString()
                    ));
            }
            return true;
        }
    }
}
