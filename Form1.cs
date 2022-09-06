using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace VetClinicApp
{
    public partial class Form1 : Form
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["vetClinicDBConnection"].ConnectionString;
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        string imgPath = String.Empty;

        public Form1() => InitializeComponent();
        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();
            UpdateOwnerTable(dgvOwners, sqlConnection);
        }

        // Заполнение (обновление) DataGridView данными из таблицы "owner":
        public static void UpdateOwnerTable(DataGridView dgv, SqlConnection connStr)
        {
            string query = @"SELECT 
                                owner_id AS id,
                                first_name AS Имя,
                                last_name AS Фамилия,
                                adress AS Адрес,
                                phone_number AS Телефон,
                                email AS Email 
                             FROM owner";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connStr);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dgv.DataSource = dataSet.Tables[0];
        }

        // Получить id последней добавленной строки:
        public static string GetLastId(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT @@IDENTITY", sqlConnection);
            return sqlCommand.ExecuteScalar().ToString();
        }

        // Получение закодированного представления изображаения:
        public static byte[] GetBytePhoto(string imgPath)
        {
            FileStream stream = new FileStream(imgPath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);
            return reader.ReadBytes((int) stream.Length);
        }

        // Изменение данных в поле таблицы для строки, соответствующей переданному id:
        public static void UpdateData(string tableName, string columnName, string value, string id, SqlConnection sqlConnection)
        {
            if(value != "")
            {           
                string query = $"UPDATE {tableName} SET {columnName} = N'{value}' WHERE owner_id = {id}";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
        }

        // Добавление питомца:
        public static void InsertPet(string pet_type, string name, string birthday_date, string ownerId, string imgPath, SqlConnection sqlConnection)
        {
            string query = @"INSERT INTO pet(pet_type, name, birthday_date, owner, photo) 
                             VALUES (@pet_type, @name, @birthday_date, @owner, @photo);";

            DateTime petBirthday = DateTime.Parse(birthday_date);

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("owner", ownerId);
            sqlCommand.Parameters.AddWithValue("pet_type", pet_type);
            sqlCommand.Parameters.AddWithValue("name", name);
            sqlCommand.Parameters.AddWithValue("birthday_date", $"{petBirthday.Month}/{petBirthday.Day}/{petBirthday.Year}");
            sqlCommand.Parameters.AddWithValue("photo", GetBytePhoto(imgPath));

            MessageBox.Show(sqlCommand.ExecuteNonQuery() == 0 ? "Питомец не добавлен" : "Питомец успешно добавлен");
        }

        // Добавление владельца:
        public static void InsertOwner(string first_name, string last_name, string adress, string phone_number, string email, SqlConnection sqlConnection)
        {
            string query = @"INSERT INTO owner(first_name, last_name, adress, phone_number, email) 
                             VALUES (@first_name, @last_name, @adress, @phone_number, @email);";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("first_name", first_name);
            sqlCommand.Parameters.AddWithValue("last_name", last_name);
            sqlCommand.Parameters.AddWithValue("adress", adress);
            sqlCommand.Parameters.AddWithValue("phone_number", phone_number);
            sqlCommand.Parameters.AddWithValue("email", email);

            MessageBox.Show(sqlCommand.ExecuteNonQuery() == 0 ? "Владелец не добавлен" : "Владелец успешно добавлен");
        }

        // Проверка на наличие в таблице строки со значение value в колонке:
        public static bool IsInTable(string tableName, string columnName, string value, SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM {tableName} WHERE {columnName} LIKE '{value}'", sqlConnection);
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            bool hasRows = dataReader.HasRows;
            dataReader.Close();
            return hasRows;
        }

        // Установка пути к фото питомца для загрузки в таблицу "pet":
        private void btnUploadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imgPath = openFileDialog.FileName.ToString();
                string[] imgPathParts = imgPath.Split('\\');
                lblUploadImg.ForeColor = Color.Green;
                lblUploadImg.Text = "Загружен файл: " + imgPathParts[imgPathParts.Length - 1]; // Вывод имени файла *.*
            }
        }

        // Поиск по номеру телефона в таблице:
        private void tbOwnerPhone_TextChanged(object sender, EventArgs e)
        {
            (dgvOwners.DataSource as DataTable).DefaultView.RowFilter = $"Телефон LIKE '%{tbOwnerPhone.Text}%'";
        }

        // Загрузка данных владельца и питомца в БД:
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(tbOwnerPhone.Text == "+7") // Заполнен ли телефон владельца? 
            {
                MessageBox.Show("ОШИБКА: телефон владельца не заполнен");
            }
            else
            {
                if (IsInTable("owner", "phone_number", tbOwnerPhone.Text, sqlConnection)) // Телефон владельца есть в БД?
                {
                    if (tbPetType.Text == "" || tbPetName.Text == "" || tbPetBday.Text == "" || imgPath == String.Empty) // Все данные питомца НЕ заполнены?
                    {
                        MessageBox.Show("ОШИБКА: все данные питомца должны быть заполнены");
                    }
                    else // Все данные питомца заполнены
                    {
                        // Добавить в БД питомца

                        SqlCommand sqlCommand = new SqlCommand($"SELECT owner_id FROM owner WHERE phone_number='{tbOwnerPhone.Text}'", sqlConnection);
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        string ownerId = "";

                        while (dataReader.Read())
                        {
                            ownerId = dataReader.GetValue(0).ToString(); // Считывание id из БД по номеру телефона владельца
                        }
                        dataReader.Close();

                        InsertPet(tbPetType.Text, tbPetName.Text, tbPetBday.Text, ownerId, imgPath, sqlConnection);
                        lblUploadImg.ForeColor = Color.Green;
                        lblUploadImg.Text = "Данные о новом питомце успешно добавлены";
                    }
                }   
                else // Телефона нет в БД
                {
                    if (tbOwnerFName.Text == "" || tbOwnerLName.Text == "" || tbOwnerAdress.Text == "") // Остальные обязательные данные владельца НЕ заполнены?
                    {
                        MessageBox.Show("ОШИБКА: первое посещение, все данные владельца должны быть заполнены");
                    }
                    else // Остальные данные владельца заполнены
                    {
                        if (tbPetType.Text == "" || tbPetName.Text == "" || tbPetBday.Text == "" || imgPath == String.Empty) // Все данные питомца НЕ заполнены?
                        {
                            MessageBox.Show("ОШИБКА: все данные питомца должны быть заполнены");
                        }
                        else // Все данные питомца заполнены
                        {
                            // Добавить в БД владельца и питомца

                            InsertOwner(tbOwnerFName.Text, tbOwnerLName.Text, tbOwnerAdress.Text, tbOwnerPhone.Text, tbOwnerEmail.Text, sqlConnection);
                            InsertPet(tbPetType.Text, tbPetName.Text, tbPetBday.Text, GetLastId(sqlConnection), imgPath, sqlConnection);
                            UpdateOwnerTable(dgvOwners, sqlConnection);
                            lblUploadImg.ForeColor = Color.Green;
                            lblUploadImg.Text = "Данные о питомце и владельце успешно добавлены";
                        }
                    }
                }
            }
        }
    }
}
