using System.Windows.Controls;

namespace ShoesShop.UserControls
{
    public partial class UserCard : UserControl
    {
        public UserCard(int id, string name)
        {
            InitializeComponent();
            IdText.Text = "#" + id.ToString();
            NameText.Text = name;
        }
    }
}
