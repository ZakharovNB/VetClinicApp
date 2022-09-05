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
        SqlCommand sqlCommand = null;
        string imgPath = String.Empty;

        public Form1() => InitializeComponent();
        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();
            GetOwnerTable(dgvOwners, sqlConnection);
        }

        // Заполнение DataGridView данными из таблицы "owner"
        public static void GetOwnerTable(DataGridView dgv, SqlConnection connStr)
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

        // Установка пути к фото питомца для загрузки в таблицу "pet"
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

        // Загрузка данных владельца и питомца в БД
        private void btnInsert_Click(object sender, EventArgs e)
        {
            // Проверка на наличие загруженного фото питомца
            if (imgPath == String.Empty)
            {
                lblUploadImg.ForeColor = Color.Red;
                lblUploadImg.Text = "Изображение не загружено";
            }
            else 
            {
                // Передача закодированного изображения в массив "petPhoto":
                byte[] petPhoto = null;
                FileStream stream = new FileStream(imgPath, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(stream);
                petPhoto = reader.ReadBytes((int)stream.Length);


                // Проверка на заполненность телефона владельца и всех данных питомца:
                if(tbOwnerPhone.Text == "+7" || tbPetType.Text == "" || tbPetName.Text == "" || tbPetBday.Text == "")
                {
                    lblUploadImg.ForeColor = Color.Red;
                    lblUploadImg.Text = "Не все данные о питомце заполнены или не хватает номера телефона владельца";
                }
                else
                {
                    // Проверка номера телефона владельца на наличие в БД
                    sqlCommand = new SqlCommand($"SELECT * FROM owner WHERE phone_number LIKE '{tbOwnerPhone.Text}'", sqlConnection);
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        //// Раздел в разработке

                        //// номер телефона зарегестрирован (вторичное посещение пользователя):
                        ////
                        //// Внести изменения в таблицу owner, соответствующие введенным данным
                        ////
                        //// Добавить нового питомца в таблицу "pet"


                        //// Получить по номеру телефона id пользователя

                        //sqlCommand = new SqlCommand($"SELECT owner_id FROM owner WHERE phone_number = '{ tbOwnerPhone.Text }'", sqlConnection);
                        //string ownerId = sqlCommand.ExecuteScalar().ToString();
                        //string query = @"UPDATE owner
                        //                 SET first_name = N'{}', last_name = N'{}', adress = N'{}', email = '{}'
                        //                 WHERE owner_id={}";

                        //// номер телефона зарегистрирован
                        //// изменить в таблице БД внесенные данные для id, найденного по номеру телефона

                        //if (tbOwnerFName.Text != "")
                        //{
                        //    // заменить ланные в таблицу "owner" по найденному id
                        //}

                        //if (tbOwnerLName.Text != "")
                        //{
                        //    // заменить ланные в таблицу "owner" по найденному id
                        //}

                        //if (tbOwnerAdress.Text != "")
                        //{
                        //    // заменить ланные в таблицу "owner" по найденному id
                        //}

                        //if (tbOwnerEmail.Text != "")
                        //{
                        //    // заменить ланные в таблицу "owner" по найденному id
                        //}
                    }
                    else 
                    {
                        // номер телефона НЕ зарегестрирован (первое посещение пользователя):
                        //
                        // Проверить на заполненность всех полей владельца:

                        if (tbOwnerFName.Text != "" && tbOwnerLName.Text !="" && tbOwnerAdress.Text !="")
                        {
                            //Добавленив в БД данных владельца:

                            string query = @"INSERT INTO owner(first_name, last_name, adress, phone_number, email) 
                                             VALUES (@first_name, @last_name, @adress, @phone_number, @email);";

                            sqlCommand = new SqlCommand(query, sqlConnection);
                            sqlCommand.Parameters.AddWithValue("first_name", tbOwnerFName.Text);
                            sqlCommand.Parameters.AddWithValue("last_name", tbOwnerLName.Text);
                            sqlCommand.Parameters.AddWithValue("adress", tbOwnerAdress.Text);
                            sqlCommand.Parameters.AddWithValue("phone_number", tbOwnerPhone.Text);
                            sqlCommand.Parameters.AddWithValue("email", tbOwnerEmail.Text);

                            if (sqlCommand.ExecuteNonQuery() == 0)
                            {
                                MessageBox.Show("Владелец не добавлен");
                            }

                            // Добавление в БД данных питомца:

                            query = "SELECT @@IDENTITY"; //Получение id последнего добавленного владельца
                            sqlCommand = new SqlCommand(query, sqlConnection);
                            string ownerId = sqlCommand.ExecuteScalar().ToString();

                            query = @"INSERT INTO pet(pet_type, name, birthday_date, owner, photo) 
                                      VALUES (@pet_type, @name, @birthday_date, @owner, @photo);";

                            DateTime petBirthday = DateTime.Parse(tbPetBday.Text);

                            sqlCommand = new SqlCommand(query, sqlConnection);
                            sqlCommand.Parameters.AddWithValue("pet_type", tbPetType.Text);
                            sqlCommand.Parameters.AddWithValue("name", tbPetName.Text);
                            sqlCommand.Parameters.AddWithValue("birthday_date", $"{petBirthday.Month}/{petBirthday.Day}/{petBirthday.Year}");
                            sqlCommand.Parameters.AddWithValue("owner", ownerId);
                            sqlCommand.Parameters.AddWithValue("photo", petPhoto);

                            if (sqlCommand.ExecuteNonQuery() == 0)
                            {
                                MessageBox.Show("Питомец не добавлен");
                            }

                            GetOwnerTable(dgvOwners, sqlConnection); // обновление данных в DataGridView после добавления данных

                            lblUploadImg.ForeColor = Color.Green;
                            lblUploadImg.Text = "Данные о питомце и владельце успешно добавлены";
                        }
                        else
                        {
                            lblUploadImg.ForeColor = Color.Red;
                            lblUploadImg.Text = "Не все необходимые данные о владельце заполнены";
                        }
                    }
                }
            }  
        }

        // Поиск по номеру телефона в таблице:

        private void tbOwnerPhone_TextChanged(object sender, EventArgs e)
        {
            (dgvOwners.DataSource as DataTable).DefaultView.RowFilter = $"Телефон LIKE '%{tbOwnerPhone.Text}%'";
        }
    }
}
