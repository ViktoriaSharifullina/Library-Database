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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Library
{
    public partial class Employee : Form
    {
        public Employee()
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
                string query = "SELECT * FROM Сотрудник";
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
                        dataGridView1.Rows.Add(dbReader["КодСотрудника"], dbReader["Табельный номер"], dbReader["Фамилия"],
                            dbReader["Имя"], dbReader["Отчество"], dbReader["Дата рождения"], dbReader["Должность"], dbReader["Образование"]);
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
                    dataGridView1.Rows[index].Cells[2].Value == null ||
                    dataGridView1.Rows[index].Cells[3].Value == null ||
                    dataGridView1.Rows[index].Cells[4].Value == null ||
                    dataGridView1.Rows[index].Cells[5].Value == null ||
                    dataGridView1.Rows[index].Cells[6].Value == null ||
                    dataGridView1.Rows[index].Cells[7].Value == null)
                {
                    MessageBox.Show("Не все данные введены!", "Внимание!");
                    return;
                }

                var patternNumeric = @"([0-9])+";
                var patternAlphabetic = @"([АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя])+";
                var regex = new Regex(patternNumeric);
                var regex_ = new Regex(patternAlphabetic);
                //Проверим данные таблицы

                if (!regex.Match((string)dataGridView1.Rows[index].Cells[0].Value).Success ||
                    !regex.Match((string)dataGridView1.Rows[index].Cells[1].Value).Success)
                {
                    MessageBox.Show("Введите число!", "Внимание!");
                    return;
                }

                if (!TextIsDate(dataGridView1.Rows[index].Cells[5].Value.ToString()))
                {
                    MessageBox.Show("Введите дату в формате \"dd-MM-yyyy\"!", "Внимание!");
                    return;
                }

                if (!regex_.Match((string)dataGridView1.Rows[index].Cells[2].Value).Success ||
                    !regex_.Match((string)dataGridView1.Rows[index].Cells[3].Value).Success ||
                    !regex_.Match((string)dataGridView1.Rows[index].Cells[4].Value).Success ||
                    !regex_.Match((string)dataGridView1.Rows[index].Cells[6].Value).Success ||
                    !regex_.Match((string)dataGridView1.Rows[index].Cells[7].Value).Success)
                {
                    MessageBox.Show("Введите слово!", "Внимание!");
                    return;
                }

                //считаем данные
                string employee_code = dataGridView1.Rows[index].Cells[0].Value.ToString();
                string number = dataGridView1.Rows[index].Cells[1].Value.ToString();
                string surname = dataGridView1.Rows[index].Cells[2].Value.ToString();
                string name = dataGridView1.Rows[index].Cells[3].Value.ToString();
                string patronymic = dataGridView1.Rows[index].Cells[4].Value.ToString();
                DateTime date = Convert.ToDateTime(dataGridView1.Rows[index].Cells[5].Value);
                string work_title = dataGridView1.Rows[index].Cells[6].Value.ToString();
                string education = dataGridView1.Rows[index].Cells[7].Value.ToString();

                //создаем соединение
                OleDbConnection dbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                       @"Data Source=""C:\Users\Админ\Desktop\БД\Library.accdb""");

                dbConnection.Open();

                string query = "INSERT INTO Сотрудник VALUES (" + employee_code + ", " + number + ",'" + surname + "','" + name + "','" +
                    patronymic + "', '" + date + "','" + work_title + "','" + education + "')";
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
                if (dataGridView1.Rows[index].Cells[0].Value == null ||
                    dataGridView1.Rows[index].Cells[1].Value == null ||
                    dataGridView1.Rows[index].Cells[2].Value == null ||
                    dataGridView1.Rows[index].Cells[3].Value == null ||
                    dataGridView1.Rows[index].Cells[4].Value == null ||
                    dataGridView1.Rows[index].Cells[5].Value == null ||
                    dataGridView1.Rows[index].Cells[6].Value == null ||
                    dataGridView1.Rows[index].Cells[7].Value == null)
                {
                    MessageBox.Show("Не все данные введены!", "Внимание!");
                    return;
                }

                var patternNumeric = @"([0-9])+";
                var patternAlphabetic = @"([АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя])+";
                var regex = new Regex(patternNumeric);
                var regex_ = new Regex(patternAlphabetic);

                Console.WriteLine(dataGridView1.Rows[index].Cells[0].ValueType);

                //Проверим данные таблицы
                /*
                if (!regex.Match((string)dataGridView1.Rows[index].Cells[0].Value).Success ||
                    !regex.Match((string)dataGridView1.Rows[index].Cells[1].Value).Success)
                {
                    MessageBox.Show("Введите число!", "Внимание!");
                    return;
                }

                if (!TextIsDate(dataGridView1.Rows[index].Cells[5].Value.ToString()))
                {
                    MessageBox.Show("Введите дату в формате \"dd-MM-yyyy\"!", "Внимание!");
                    return;
                }

                if (!regex_.Match(dataGridView1.Rows[index].Cells[2].Value.ToString()).Success ||
                    !regex_.Match(dataGridView1.Rows[index].Cells[3].ToString()).Success ||
                    !regex_.Match(dataGridView1.Rows[index].Cells[4].ToString()).Success ||
                    !regex_.Match(dataGridView1.Rows[index].Cells[6].ToString()).Success ||
                    !regex_.Match(dataGridView1.Rows[index].Cells[7].ToString()).Success)
                {
                    MessageBox.Show("Введите слово!", "Внимание!");
                    return;
                }*/

                //считаем данные
                string employee_code = dataGridView1.Rows[index].Cells[0].Value.ToString();
                string number = dataGridView1.Rows[index].Cells[1].Value.ToString();
                string surname = dataGridView1.Rows[index].Cells[2].Value.ToString();
                string name = dataGridView1.Rows[index].Cells[3].Value.ToString();
                string patronymic = dataGridView1.Rows[index].Cells[4].Value.ToString();
                DateTime date = Convert.ToDateTime(dataGridView1.Rows[index].Cells[5].Value);
                string work_title = dataGridView1.Rows[index].Cells[6].Value.ToString();
                string education = dataGridView1.Rows[index].Cells[7].Value.ToString();

                //создаем соединение
                OleDbConnection dbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                       @"Data Source=""C:\Users\Админ\Desktop\БД\Library.accdb""");

                dbConnection.Open();

                string query = "UPDATE Сотрудник SET [Табельный номер] =" + number + ", [Фамилия] = '" + surname + "', [Имя] = '" + name + "', [Отчество] = '" +
                    patronymic + "', [Дата рождения] = '" + date + "' , [Должность] = '" + work_title + "', [Образование] = '" + education + "' WHERE [КодСотрудника] = " + employee_code;
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
                    MessageBox.Show("Нельзя удалить сотрудника без кода!", "Внимание!");
                    return;
                }

                //считаем данные
                string employee_code = dataGridView1.Rows[index].Cells[0].Value.ToString();

                //создаем соединение
                OleDbConnection dbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                                       @"Data Source=""C:\Users\Админ\Desktop\БД\Library.accdb""");

                dbConnection.Open();
                string query = "DELETE FROM Сотрудник WHERE [КодСотрудника] = " + employee_code;
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

        private void Employee_Load(object sender, EventArgs e)
        {

        }
    }
}
