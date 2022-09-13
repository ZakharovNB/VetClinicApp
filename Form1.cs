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
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlCommandBuilder = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null;
        string imgPath = String.Empty;

        public Form1() => InitializeComponent();
        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["vetClinicDBConnection"].ConnectionString);
            sqlConnection.Open();
            LoadOwnerTable();
        }

        // Заполнение DataGridView данными из таблиц "owner" и "pet":
        public void LoadOwnerTable()
        {            
            string query = @"SELECT 
                                owner_id AS [Id владельца],
                                first_name AS [Имя],
                                last_name AS [Фамилия],
                                adress AS [Адрес],
                                phone_number AS [Телефон],
                                email AS [E-mail],
                                (SELECT string_agg(pet_id, ', ') FROM pet WHERE owner = owner_id) AS [Id питомцев]
                             FROM owner";

            sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            sqlCommandBuilder.GetUpdateCommand();
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Owner");
            dgvOwners.DataSource = dataSet.Tables["Owner"];
            dgvOwners.Columns["id владельца"].ReadOnly = true; // id только для чтения
        }

        // Обновление DataGridView данными из таблицы "owner":
        public void ReloadOwnerTable()
        {
            dataSet.Tables["Owner"].Clear();
            sqlDataAdapter.Fill(dataSet, "Owner");
            dgvOwners.DataSource = dataSet.Tables["Owner"];
            lblUploadImg.ForeColor = Color.Green;
            lblUploadImg.Text = "Данные в таблице обновлены";
        }

        // Получить id последней добавленной строки:
        public string GetLastId()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT @@IDENTITY", sqlConnection);
            return sqlCommand.ExecuteScalar().ToString();
        }

        // Получение закодированного представления изображаения:
        public byte[] GetBytePhoto()
        {
            FileStream stream = new FileStream(imgPath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);
            return reader.ReadBytes((int) stream.Length);
        }

        // Добавление питомца:
        public void InsertPet(string pet_type, string name, string birthday_date, string ownerId, string imgPath)
        {
            string query = @"INSERT INTO pet(pet_type, name, birthday_date, owner, photo) 
                             VALUES (@pet_type, @name, @birthday_date, @owner, @photo);";

            DateTime petBirthday = DateTime.Parse(birthday_date);

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("owner", ownerId);
            sqlCommand.Parameters.AddWithValue("pet_type", pet_type);
            sqlCommand.Parameters.AddWithValue("name", name);
            sqlCommand.Parameters.AddWithValue("birthday_date", $"{petBirthday.Month}/{petBirthday.Day}/{petBirthday.Year}");
            sqlCommand.Parameters.AddWithValue("photo", GetBytePhoto());

            MessageBox.Show(sqlCommand.ExecuteNonQuery() == 0 ? "Питомец не добавлен" : "Питомец успешно добавлен");
        }

        // Добавление владельца:
        public void InsertOwner(string first_name, string last_name, string adress, string phone_number, string email)
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
        public bool IsInTable(string tableName, string columnName, string value)
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
                if (IsInTable("owner", "phone_number", tbOwnerPhone.Text)) // Телефон владельца есть в БД?
                {
                    if (tbPetType.Text == "" || tbPetName.Text == "" || tbPetBday.Text == "" || imgPath == String.Empty) // Все данные питомца НЕ заполнены?
                    {
                        MessageBox.Show("ОШИБКА: все данные питомца должны быть заполнены");
                        if (imgPath == String.Empty)
                        {
                            lblUploadImg.ForeColor = Color.Red;
                            lblUploadImg.Text = "Загрузите фотографию питомца";
                        }
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

                        InsertPet(tbPetType.Text, tbPetName.Text, tbPetBday.Text, ownerId, imgPath);
                        ReloadOwnerTable();
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
                            if (imgPath == String.Empty)
                            {
                                lblUploadImg.ForeColor = Color.Red;
                                lblUploadImg.Text = "Загрузите фотографию питомца";
                            }
                        }
                        else // Все данные питомца заполнены
                        {
                            // Добавить в БД владельца и питомца

                            InsertOwner(tbOwnerFName.Text, tbOwnerLName.Text, tbOwnerAdress.Text, tbOwnerPhone.Text, tbOwnerEmail.Text);
                            InsertPet(tbPetType.Text, tbPetName.Text, tbPetBday.Text, GetLastId(), imgPath);
                            ReloadOwnerTable();
                            lblUploadImg.ForeColor = Color.Green;
                            lblUploadImg.Text = "Данные о питомце и владельце успешно добавлены";
                        }
                    }
                }
            }
        }

        // Очистка полей от введенных данных:
        private void btnResetData_Click(object sender, EventArgs e)
        {
            tbOwnerFName.Text = String.Empty;
            tbOwnerLName.Text = String.Empty;
            tbOwnerAdress.Text = String.Empty;
            tbOwnerPhone.Text = String.Empty;
            tbOwnerEmail.Text = String.Empty;
            tbPetType.Text = String.Empty;
            tbPetName.Text = String.Empty;
            tbPetBday.Text = String.Empty;
            imgPath = String.Empty;
        }

        // Внесение изменений из DataGridView в БД при нажатии клавиши Enter
        private void dgvOwners_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                DataTable dt = dgvOwners.DataSource as DataTable;
                int rowIndex = dgvOwners.SelectedCells[0].RowIndex;
                dataSet.Tables["Owner"].Rows[rowIndex][1] = dt.Rows[rowIndex]["Имя"];
                dataSet.Tables["Owner"].Rows[rowIndex][2] = dt.Rows[rowIndex]["Фамилия"];
                dataSet.Tables["Owner"].Rows[rowIndex][3] = dt.Rows[rowIndex]["Адрес"];
                dataSet.Tables["Owner"].Rows[rowIndex][4] = dt.Rows[rowIndex]["Телефон"];
                dataSet.Tables["Owner"].Rows[rowIndex][5] = dt.Rows[rowIndex]["E-mail"];
                sqlDataAdapter.Update(dataSet, "Owner");
                MessageBox.Show("Данные успешно изменены");
                lblUploadImg.ForeColor = Color.Black;
                lblUploadImg.Text = "...";
            }
        }

        // Отслеживание изменения в DataGridView
        private void dgvOwners_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            lblUploadImg.ForeColor = Color.Orange;
            lblUploadImg.Text = "Нажмите Enter для применения изменений";
        }
    }
}
