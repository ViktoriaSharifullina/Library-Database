using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Poisk_1_storage : Form
    {

        public Poisk_1_storage()
        {
            InitializeComponent();
        }

        private void button_find_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection dbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                   @"Data Source=""C:\Users\Админ\Desktop\БД\Library.accdb""");
                dbConnection.Open();
                string number = textBox1.Text;
                string query = "SELECT * FROM Хранилище WHERE [Номер хранилища] = " + number;
                OleDbDataAdapter command = new OleDbDataAdapter(query, dbConnection);
                DataTable dt = new DataTable();
                command.Fill(dt);
                dataGridView1.DataSource = dt;

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

        private void Poisk_1_storage_Load(object sender, EventArgs e)
        {

        }
    }
}
