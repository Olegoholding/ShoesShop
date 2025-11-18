using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

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
                    MessageBox.Show(ex.Message, ex.HResult.ToString());
                    return DataTable;
                }
            }
        }
        public DataTable DeleteData(TextBlock cellContent, string Tag)
        {
            int ID = int.Parse(cellContent.Text);
            string command = $"DELETE FROM {Tag} WHERE Номер = {ID}";
            try
            {
                using (Conn = new MySqlConnection(ConnStr))
                {
                    if (cellContent is TextBlock textBlock)
                    {
                        ID = int.Parse(textBlock.Text);
                    }
                    Cmd = new MySqlCommand(command, Conn);
                    try
                    {
                        Conn.Open();
                        int rowsAffected = Cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
            return GetData(Command);
        }
        public DataTable InsertData(string TableName, DataView DataView)
        {
            var DataSet = new DataSet();
            var DataTable = DataView.Table;
            DataTable.TableName = TableName;
            DataSet.Tables.Add(DataTable);
            try
            {
                using (Conn = new MySqlConnection(ConnStr))
                {
                    Adapter = new MySqlDataAdapter();
                    Adapter.SelectCommand = new MySqlCommand(Command, Conn);
                    var builder = new MySqlCommandBuilder(Adapter);

                    Adapter.InsertCommand = builder.GetInsertCommand();
                    Adapter.Update(DataSet, TableName);
                }
                DataSet.Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return GetData(Command);
        }
    }
}
