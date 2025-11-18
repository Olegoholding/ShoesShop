using ShoesShop.Back;
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
            SrcLabel.Text = $"Поиск по {uid}";
            Tag = tag;
            Uid = uid;

            DataGrid.ItemsSource = db.GetData($"Select * from {tag}").DefaultView;
        }
        private void Search(object sender, RoutedEventArgs e)
        {
            if(SrcBox.Text == "")
            {
                MessageBox.Show("Сначала заполните текстовое поле!", "Ошибка!");
                return;
            }
            DataGrid.ItemsSource = db.GetData($"Select * from {Tag} where {Uid} = '{SrcBox.Text}'").DefaultView;
        }
        private void Add(object sender, RoutedEventArgs e) => db.InsertData(Tag, (DataView)DataGrid.ItemsSource);
        private void Delete(object sender, RoutedEventArgs e) => DataGrid.ItemsSource = db.DeleteData((TextBlock)DataGrid.Columns[0].GetCellContent(DataGrid.SelectedItem), Tag).DefaultView;
    }
}
