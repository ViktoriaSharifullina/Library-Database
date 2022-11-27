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
    public partial class Book : Form
    {
        public Book()
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
                string query = "SELECT * FROM Книга";
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
                        dataGridView1.Rows.Add(dbReader["Номер книги"], dbReader["Шифр книги"], dbReader["Автор"],
                            dbReader["Название"], dbReader["Издательство"], dbReader["Год издания"], dbReader["Цена"],
                            dbReader["Дата поступления"], dbReader["Номер хранилища"]);
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
                int index = dataGridView1.SelectedRows[0].Index;

                //Проверим данные таблицы
                for (int i = 0; i < 9; i++)
                {
                    if (dataGridView1.Rows[index].Cells[i].Value == null)
                    {
                        MessageBox.Show("Не все данные введены!", "Внимание!");
                        return;
                    }
                }

                var patternNumeric = @"([0-9])+";
                var patternAlphabetic = @"([АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя])+";
                var regex = new Regex(patternNumeric);
                var regex_ = new Regex(patternAlphabetic);
                //Проверим данные таблицы

                if (!regex.Match((string)dataGridView1.Rows[index].Cells[0].Value).Success ||
                    !regex.Match((string)dataGridView1.Rows[index].Cells[1].Value).Success ||
                    !regex.Match((string)dataGridView1.Rows[index].Cells[6].Value).Success ||
                    !regex.Match((string)dataGridView1.Rows[index].Cells[8].Value).Success)
                {
                    MessageBox.Show("Введите число!", "Внимание!");
                    return;
                }

                if (!regex_.Match((string)dataGridView1.Rows[index].Cells[2].Value).Success ||
                    !regex_.Match((string)dataGridView1.Rows[index].Cells[3].Value).Success ||
                    !regex_.Match((string)dataGridView1.Rows[index].Cells[4].Value).Success)
                {
                    MessageBox.Show("Введите только буквы!", "Внимание!");
                    return;
                }

                if (!TextIsDate(dataGridView1.Rows[index].Cells[5].Value.ToString()) ||
                    !TextIsDate(dataGridView1.Rows[index].Cells[7].Value.ToString()))
                {
                    MessageBox.Show("Введите дату в формате \"dd-MM-yyyy\"!", "Внимание!");
                    return;
                }

                //считаем данные
                string number = dataGridView1.Rows[index].Cells[0].Value.ToString();
                string code = dataGridView1.Rows[index].Cells[1].Value.ToString();
                string author = dataGridView1.Rows[index].Cells[2].Value.ToString();
                string name = dataGridView1.Rows[index].Cells[3].Value.ToString();
                string pub_house = dataGridView1.Rows[index].Cells[4].Value.ToString();
                DateTime year = Convert.ToDateTime(dataGridView1.Rows[index].Cells[5].Value);
                string price = dataGridView1.Rows[index].Cells[6].Value.ToString();
                DateTime date = Convert.ToDateTime(dataGridView1.Rows[index].Cells[7].Value);
                string storage = dataGridView1.Rows[index].Cells[8].Value.ToString();


                //создаем соединение
                OleDbConnection dbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                       @"Data Source=""C:\Users\Админ\Desktop\БД\Library.accdb""");

                dbConnection.Open();
                string query = "INSERT INTO Книга VALUES (" + number + ", " + code + ", '" + author +
                    "', '" + name + "', '" + pub_house + "', '" + year + "', " + price + ", '" + date + "', " + storage + ")";
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
                for (int i = 0; i < 9; i++)
                {
                    if (dataGridView1.Rows[index].Cells[i].Value == null)
                    {
                        MessageBox.Show("Не все данные введены!", "Внимание!");
                        return;
                    }
                }

                //считаем данные
                string number = dataGridView1.Rows[index].Cells[0].Value.ToString();
                string code = dataGridView1.Rows[index].Cells[1].Value.ToString();
                string author = dataGridView1.Rows[index].Cells[2].Value.ToString();
                string name = dataGridView1.Rows[index].Cells[3].Value.ToString();
                string pub_house = dataGridView1.Rows[index].Cells[4].Value.ToString();
                DateTime year = Convert.ToDateTime(dataGridView1.Rows[index].Cells[5].Value);
                string price = dataGridView1.Rows[index].Cells[6].Value.ToString();
                DateTime date = Convert.ToDateTime(dataGridView1.Rows[index].Cells[7].Value);
                string storage = dataGridView1.Rows[index].Cells[8].Value.ToString();

                //создаем соединение
                OleDbConnection dbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                       @"Data Source=""C:\Users\Админ\Desktop\БД\Library.accdb""");

                dbConnection.Open();
                string query = "UPDATE Книга SET [Шифр книги] = " + code + ", Автор = '" + author +
                    "', Название='" + name + "', Издательство='" + pub_house + "', [Год издания] = '" + year
                    + "', Цена=" + price + ", [Дата поступления] = '" + date + "', [Номер хранилища] = " + storage + " WHERE [Номер книги] = " + number;
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
                    MessageBox.Show("Нельзя удалить книгу без номера!", "Внимание!");
                    return;
                }

                //считаем данные
                string number = dataGridView1.Rows[index].Cells[0].Value.ToString();

                //создаем соединение
                OleDbConnection dbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                       @"Data Source=""C:\Users\Админ\Desktop\БД\Library.accdb""");

                dbConnection.Open();
                string query = "DELETE FROM Книга WHERE [Номер книги] = " + number;
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

        private void Book_Load(object sender, EventArgs e)
        {

        }
    }
}
