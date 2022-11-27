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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Library
{
    public partial class Poisk_2_storage : Form
    {
        public Poisk_2_storage()
        {
            InitializeComponent();
        }

        private void Poisk_2_storage_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection dbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                   @"Data Source=""C:\Users\Админ\Desktop\БД\Library.accdb""");
                dbConnection.Open();
                int capacity = 7000;
                string query = "SELECT * FROM Хранилище WHERE [Вместимость] > " + capacity;
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
    }
}
