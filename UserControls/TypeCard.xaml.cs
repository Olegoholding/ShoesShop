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
using ZstdSharp.Unsafe;
using static System.Net.Mime.MediaTypeNames;

namespace ShoesShop.UserControls
{
    /// <summary>
    /// Логика взаимодействия для GoodsType.xaml
    /// </summary>
    public partial class GoodsType : UserControl
    {
        int _id;
        string _name;

        public GoodsType(int id, string name)
        {
            _id = id;
            _name = name;

            LoadCard();
            InitializeComponent();
        }

        private void LoadCard()
        {
            IdText.Text = "#" + _id.ToString();
            NameText.Text = _name;
        }        
    }
}
