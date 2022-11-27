using System.Data.OleDb;
using System.Text.RegularExpressions;

namespace Library
{
    public partial class Storage : Form
    {
       
        public Storage()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Owner.Show();  //Show Form assigning this form as the forms owner
            Hide();
        }

        private void button_download_Click(object sender, EventArgs e)
        {
            try
            {
                //создаем соединение
                OleDbConnection dbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                        @"Data Source=""C:\Users\Админ\Desktop\БД\Library.accdb""");

                //выполняем запрос к БД
                dbConnection.Open();
                string query = "SELECT * FROM Хранилище";
                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
                OleDbDataReader dbReader = dbCommand.ExecuteReader();

                if (dbReader.HasRows == false)
                {
                    MessageBox.Show("Данные не найдены!", "Ошибка!");
                    return;
                }
                else
                {
                    dataGridView1.Rows.Clear();
                    while (dbReader.Read())
                    {
                        dataGridView1.Rows.Add(dbReader["Номер хранилища"], dbReader["Этаж"], dbReader["Вместимость"]);
                    }
                }

                dbReader.Close();
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

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    MessageBox.Show("Выберите одну строку!", "Внимание!");
                    return;
                }
                //Запомним выбранную строку
                int index = dataGridView1.SelectedRows[0].Index;

                //Проверим данные таблицы
                if (dataGridView1.Rows[index].Cells[0].Value == null ||
                    dataGridView1.Rows[index].Cells[1].Value == null ||
                    dataGridView1.Rows[index].Cells[2].Value == null)
                {
                    MessageBox.Show("Не все данные введены!", "Внимание!");
                    return;
                }
                var patternNumeric = @"([0-9])+";
                var regex = new Regex(patternNumeric);
                //Проверим данные таблицы
                if (!regex.Match((string)dataGridView1.Rows[index].Cells[0].Value).Success ||
                    !regex.Match((string)dataGridView1.Rows[index].Cells[1].Value).Success ||
                    !regex.Match((string)dataGridView1.Rows[index].Cells[2].Value).Success)
                {
                    MessageBox.Show("Введите число!", "Внимание!");
                    return;
                }

                //считаем данные
                string number_storage = dataGridView1.Rows[index].Cells[0].Value.ToString();
                string floor = dataGridView1.Rows[index].Cells[1].Value.ToString();
                string capacity = dataGridView1.Rows[index].Cells[2].Value.ToString();

                //создаем соединение
                OleDbConnection dbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                       @"Data Source=""C:\Users\Админ\Desktop\БД\Library.accdb""");

                dbConnection.Open();
                string query = "INSERT INTO Хранилище VALUES (" + number_storage + ", " + floor + ", " + capacity + ")";
                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

                if (dbCommand.ExecuteNonQuery() != 1)
                {
                    MessageBox.Show("Ошибка выполнения запроса!", "Внимание");
                }
                else
                {
                    MessageBox.Show("Данные добавлены!", "Внимание");
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

        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    MessageBox.Show("Выберите одну строку!", "Внимание!");
                    return;
                }

                //Запомним выбранную строку
                int index = dataGridView1.SelectedRows[0].Index;

                //Проверим данные таблицы
                if (dataGridView1.Rows[index].Cells[0].Value == null ||
                    dataGridView1.Rows[index].Cells[1].Value == null ||
                    dataGridView1.Rows[index].Cells[2].Value == null)
                {
                    MessageBox.Show("Не все данные введены!", "Внимание!");
                    return;
                }
                var patternNumeric = @"([0-9])+";
                var regex = new Regex(patternNumeric);
                /*
                if (dataGridView1.Rows[index].Cells[0].Value is Int32 or  ||
                    dataGridView1.Rows[index].Cells[1].Value is Int32 ||
                    dataGridView1.Rows[index].Cells[2].Value is Int32)
                {
                    MessageBox.Show("Введите число!", "Внимание!");
                    return;
                }
                */
                //считаем данные
                string number_storage = dataGridView1.Rows[index].Cells[0].Value.ToString();
                string floor = dataGridView1.Rows[index].Cells[1].Value.ToString();
                string capacity = dataGridView1.Rows[index].Cells[2].Value.ToString();

                //создаем соединение
                OleDbConnection dbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                       @"Data Source=""C:\Users\Админ\Desktop\БД\Library.accdb""");

                dbConnection.Open();
                string query = "UPDATE Хранилище SET Этаж = " + floor + ", Вместимость = " + capacity + " WHERE [Номер хранилища] = " + number_storage;
                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

                if (dbCommand.ExecuteNonQuery() != 1)
                {
                    MessageBox.Show("Ошибка выполнения запроса!", "Внимание");
                }
                else
                {
                    MessageBox.Show("Данные изменены!", "Внимание");
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

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    MessageBox.Show("Выберите одну строку!", "Внимание!");
                    return;
                }

                //Запомним выбранную строку
                int index = dataGridView1.SelectedRows[0].Index;

                //Проверим данные таблицы
                if (dataGridView1.Rows[index].Cells[0].Value == null)
                {
                    MessageBox.Show("Нельзя удалить хранилище без номера!", "Внимание!");
                    return;
                }

                //считаем данные
                string number_storage = dataGridView1.Rows[index].Cells[0].Value.ToString();

                //создаем соединение
                OleDbConnection dbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                       @"Data Source=""C:\Users\Админ\Desktop\БД\Library.accdb""");

                dbConnection.Open();
                string query = "DELETE FROM Хранилище WHERE [Номер хранилища] = " + number_storage;
                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

                if (dbCommand.ExecuteNonQuery() != 1)
                {
                    MessageBox.Show("Ошибка выполнения запроса!", "Внимание");
                }
                else
                {
                    MessageBox.Show("Данные удалены!", "Внимание");
                    dataGridView1.Rows.RemoveAt(index);
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void поискХранилищаПоНомеруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Poisk_1_storage p1 = new Poisk_1_storage();
            p1.Owner = this;
            p1.Show();
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete_1_storage d1 = new Delete_1_storage();
            d1.Owner = this;
            d1.Show();
        }

        private void поискХранилищаПоВместмостиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Poisk_2_storage d1 = new Poisk_2_storage();
            d1.Owner = this;
            d1.Show();
        }

        private void Storage_Load(object sender, EventArgs e)
        {

        }
    }
}
