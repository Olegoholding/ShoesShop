using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.Ocsp;
using ShoesShop.Back;
using ShoesShop.UserControls;
using System.Data;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShoesShop.Pages
{
    public partial class DataPage : Page
    {
        string TagElem;
        string CurrentCards;
        public DataPage(string tag, string curCards)
        {
            InitializeComponent();

            TagElem = tag;
            CurrentCards = curCards;
            wrapPanel.Children.Clear();
            Type type = this.GetType();
            MethodInfo method = type.GetMethod(TagElem);
            DataTable dt = new DatabaseInteraction().GetData($"Select * from {TagElem}_view");
            method.Invoke(this, new object[] { dt });
        }
        public void Пользователи(DataTable dt)
        {
            DltComboBox.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                DltComboBox.Items.Add((int)(row["Номер"]));
                wrapPanel.Children.Add(new UserCard(Convert.ToInt16(row["Номер"]), row["Логин"].ToString()));
            }
            Label0.Text = "Логин";
            Label1.Text = "Пароль";

            Label2.Visibility = Visibility.Hidden;
            Text2.Visibility = Visibility.Hidden;
            Label3.Visibility = Visibility.Hidden;
            Text3.Visibility = Visibility.Hidden;
            Label4.Visibility = Visibility.Hidden;
            Text4.Visibility = Visibility.Hidden;
            Label5.Visibility = Visibility.Hidden;
            Text5.Visibility = Visibility.Hidden;
        }
        public void Заказы(DataTable dt)
        {
            int cost = 0;
            DltComboBox.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                cost = Convert.ToInt16(row["Колво"]) * Convert.ToInt16(row["Цена"]);
                DltComboBox.Items.Add((int)(row["Номер"]));
                wrapPanel.Children.Add(new OrdersCard((int)(row["Номер"]), row["Фамилия"].ToString(), row["Название"].ToString(), row["Колво"].ToString(),cost));
            }
            Label0.Text = "Фамилия";
            Label1.Text = "Имя";
            Label2.Text = "Номер товара";
            Label3.Text = "Кол-во";

            Label4.Visibility = Visibility.Hidden;
            Text4.Visibility = Visibility.Hidden;
            Label5.Visibility = Visibility.Hidden;
            Text5.Visibility = Visibility.Hidden;
        }
        public void Товары(DataTable dt)
        {
            DltComboBox.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                DltComboBox.Items.Add((int)(row["Номер"]));
                wrapPanel.Children.Add(new GoodsCard(
                row["Изображение"].ToString(),
                row["Название"].ToString(),
                row["Цена"].ToString() + " руб"));
            }
            Label3.Text = "Тип";
            Label4.Text = "Размер";
            Label5.Text = "Колво";
        }
        public void Тип(DataTable dt)
        {
            DltComboBox.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                DltComboBox.Items.Add((int)(row["Номер"]));

                wrapPanel.Children.Add(new GoodsType(
                Convert.ToInt16(row["Номер"]),
                row["Название"].ToString()));
            }
            Label0.Text = "Название";

            Label1.Visibility = Visibility.Hidden;
            Text1.Visibility = Visibility.Hidden;
            Label2.Visibility = Visibility.Hidden;
            Text2.Visibility = Visibility.Hidden;
            Label3.Visibility = Visibility.Hidden;
            Text3.Visibility = Visibility.Hidden;
            Label4.Visibility = Visibility.Hidden;
            Text4.Visibility = Visibility.Hidden;
            Label5.Visibility = Visibility.Hidden;
            Text5.Visibility = Visibility.Hidden;
        }
        private void SrcBtn_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            for (int i = wrapPanel.Children.Count - 1; i >= 0; i--)
            {
                var item = wrapPanel.Children[i];

                dynamic dynamicItem = item;
                if (dynamicItem.NameText.Text != SrcBox.Text)
                {
                    wrapPanel.Children.RemoveAt(i);
                }
            }
        }
        private void TextBlock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => new DatabaseInteraction().DeleteData(TagElem, Convert.ToInt16(DltComboBox.Text));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string command = "";
            switch (CurrentCards)
            {
                case "TypeCards":
                    command = $"INSERT INTO Тип (Название) VALUES('{Text0.Text}');";
                    break;
                case "GoodsCard":
                    command = $"INSERT INTO Товары (Название, Цена, Тип, Размер, Колво, Изображение) VALUES('{Text1.Text}', '{Text2.Text}', {Convert.ToInt16(Text3.Text)}, {Convert.ToInt16(Text4.Text)}, {Convert.ToInt16(Text5.Text)}, '{Text0.Text}');";
                    break;
                case "OrdersCard":
                    command = $"INSERT INTO Заказы (ФамилияПокупателя, ИмяПокупателя, Товар, Колво) VALUES('{Text0.Text}', '{Text1.Text}', {Convert.ToInt16(Text2.Text)}, {Convert.ToInt16(Text3.Text)});";
                    break;
                case "UserCards":
                    command = $"INSERT INTO Пользователи (Логин, Пароль) VALUES('{Text0.Text}', '{Text1.Text}');";
                    break;
            }
            DatabaseInteraction database = new DatabaseInteraction();
            database.DataInsert(command);
        }
    }
}
