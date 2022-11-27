using System.Data;
using System.Data.OleDb;

namespace Library
{
    public partial class MSysObjects : Form
    {
        public MSysObjects()
        {
            InitializeComponent();
        }

        private void MSysObjects_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection cn = new OleDbConnection(
                        @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                        @"Data Source=""C:\Users\Админ\Desktop\БД\Library.accdb"";" +
                        @"Jet OLEDB:Create System Database=true;" + // разрешение на доступ
                        @"Jet OLEDB:System database=""C:\Users\Админ\AppData\Roaming\Microsoft\Access\System.mdw""");

                cn.Open();
                string query = "SELECT MSysObjects.Id, MSysObjects.Name FROM MSysObjects WHERE MSysObjects.Type = " + 1 +
                    "AND Left([Name],4) <> '" + "MSys" + "' And Left([Name],4) <> '" + "USys" + "'";
                OleDbDataAdapter command = new OleDbDataAdapter(query, cn);
                DataTable dt = new DataTable();
                command.Fill(dt);
                dataGridView1.DataSource = dt;

                cn.Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!");
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Внимание!");
            }

            try
            {

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
