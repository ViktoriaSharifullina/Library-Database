using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Extradition : Form
    {
        public Extradition()
        {
            InitializeComponent();
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
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
                string query = "SELECT * FROM Выдача";
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
                        dataGridView1.Rows.Add(dbReader["КодВыдачи"], dbReader["Дата выдачи"], dbReader["Дата возврата"],
                            dbReader["Номер книги"], dbReader["Номер билета"]);
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
                for (int i = 0; i < 5; i++)
                {
                    if (dataGridView1.Rows[index].Cells[i].Value == null)
                    {
                        MessageBox.Show("Не все данные введены!", "Внимание!");
                        return;
                    }
                }

                var patternNumeric = @"([0-9])+"; var patternAlphabetic = @"([АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя])+";
                var regex = new Regex(patternNumeric);

                //Проверим данные таблицы

                if (!regex.Match((string)dataGridView1.Rows[index].Cells[0].Value).Success ||
                    !regex.Match((string)dataGridView1.Rows[index].Cells[3].Value).Success ||
                    !regex.Match((string)dataGridView1.Rows[index].Cells[4].Value).Success)
                {
                    MessageBox.Show("Введите число!", "Внимание!");
                    return;
                }

                if (!TextIsDate(dataGridView1.Rows[index].Cells[1].Value.ToString()) ||
                    !TextIsDate(dataGridView1.Rows[index].Cells[2].Value.ToString()))
                {
                    MessageBox.Show("Введите дату в формате \"dd-MM-yyyy\"!", "Внимание!");
                    return;
                }

                //считаем данные
                string code = dataGridView1.Rows[index].Cells[0].Value.ToString();
                DateTime date_ex = Convert.ToDateTime(dataGridView1.Rows[index].Cells[1].Value);
                DateTime date_ret = Convert.ToDateTime(dataGridView1.Rows[index].Cells[2].Value);
                string number_book = dataGridView1.Rows[index].Cells[3].Value.ToString();
                string number_ticket = dataGridView1.Rows[index].Cells[4].Value.ToString();


                //создаем соединение
                OleDbConnection dbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                       @"Data Source=""C:\Users\Админ\Desktop\БД\Library.accdb""");

                dbConnection.Open();
                string query = "INSERT INTO Выдача VALUES (" + code + ", '" + date_ex + "', '" + date_ret +
                    "', " + number_book + ", " + number_ticket + ")";
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

        static bool TextIsDate(string text)
        {
            var dateFormat = "dd-MM-yyyy";
            DateTime scheduleDate;
            if (DateTime.TryParseExact(text, dateFormat, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out scheduleDate))
            {
                return true;
            }
            return false;
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
                for (int i = 0; i < 5; i++)
                {
                    if (dataGridView1.Rows[index].Cells[i].Value == null)
                    {
                        MessageBox.Show("Не все данные введены!", "Внимание!");
                        return;
                    }
                }

                //считаем данные
                string code = dataGridView1.Rows[index].Cells[0].Value.ToString();
                DateTime date_ex = Convert.ToDateTime(dataGridView1.Rows[index].Cells[1].Value);
                DateTime date_ret = Convert.ToDateTime(dataGridView1.Rows[index].Cells[2].Value);
                string number_book = dataGridView1.Rows[index].Cells[3].Value.ToString();
                string number_ticket = dataGridView1.Rows[index].Cells[4].Value.ToString();

                //создаем соединение
                OleDbConnection dbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                       @"Data Source=""C:\Users\Админ\Desktop\БД\Library.accdb""");

                dbConnection.Open();
                string query = "UPDATE Выдача SET [Дата выдачи] = '" + date_ex + "', [Дата возврата] = '" + date_ret +
                    "', [Номер книги]=" + number_book + ", [Номер билета]=" + number_ticket + " WHERE [КодВыдачи] = " + code;
                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

                try
                {
                    if (dbCommand.ExecuteNonQuery() != 1)
                    {
                        MessageBox.Show("Ошибка выполнения запроса!", "Внимание");
                    }
                    else
                    {
                        MessageBox.Show("Данные изменены!", "Внимание");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show((IWin32Window)ex, "Внимание");
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
                    MessageBox.Show("Нельзя удалить выдачу без кода!", "Внимание!");
                    return;
                }

                //считаем данные
                string code = dataGridView1.Rows[index].Cells[0].Value.ToString();

                //создаем соединение
                OleDbConnection dbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                       @"Data Source=""C:\Users\Админ\Desktop\БД\Library.accdb""");

                dbConnection.Open();
                string query = "DELETE FROM Выдача WHERE [КодВыдачи] = " + code;
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

        private void Extradition_Load(object sender, EventArgs e)
        {

        }
    }
}
