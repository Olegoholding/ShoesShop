using MySql.Data.MySqlClient;
using ShoesShop.Pages;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml.Linq;
namespace ShoesShop.Back
{

    internal class DatabaseInteraction
    {
        MySqlConnection Conn;
        MySqlCommand Cmd;
        MySqlDataAdapter Adapter;
        string Command; 
        readonly string ConnStr = "Server = 95.183.12.18; Port = 3306; Database = shoes; user = shoogaze";
        public DataTable GetData(string command)
        {
            DataTable DataTable = new DataTable();
            Command = command;
            using (Conn = new MySqlConnection($"{ConnStr}"))
            {
                try
                {
                    Conn.Open();
                    using (Cmd = new MySqlCommand($"{command}", Conn))
                    {
                        Adapter = new MySqlDataAdapter(Cmd);
                        Adapter.Fill(DataTable);
                    }
                    Conn.Close();
                    return DataTable;
                }
                catch (Exception ex)
                {
                    
                    return DataTable;
                }
            }
        }
        public DataTable DeleteData(string Tag, int ID)
        {
            string command = $"DELETE FROM {Tag} WHERE Номер = '{ID}'";
            try
            {
                using (Conn = new MySqlConnection(ConnStr))
                {
                    Cmd = new MySqlCommand(command, Conn);
                    Conn.Open();
                    try
                    {
                        int rowsAffected = Cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
            return GetData(Command);
        }
        public void DataInsert(string command)
        {
            using (Conn = new (ConnStr))
            {
                Conn.Open();
                using (Cmd = new(command, Conn))
                {
                    MessageBox.Show(command);
                    Cmd.ExecuteNonQuery();
                }
                Conn.Close();
            }
        }
#warning TO "Olegoholding"
    }
}
