using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Delete_1_storage : Form
    {
        public Delete_1_storage()
        {
            InitializeComponent();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection dbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                   @"Data Source=""C:\Users\Админ\Desktop\БД\Library.accdb""");
                dbConnection.Open();
                string number = textBox1.Text;
                string query = "DELETE FROM Хранилище WHERE [Номер хранилища] = " + number;
                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

                if (dbCommand.ExecuteNonQuery() != 1)
                {
                    MessageBox.Show("Ошибка выполнения запроса!", "Внимание");
                }
                else
                {
                    MessageBox.Show("Данные удалены!", "Внимание");

                }

                dbConnection.Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!");
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!");
            }
            
        }

        private void Delete_1_storage_Load(object sender, EventArgs e)
        {

        }
    }
}
