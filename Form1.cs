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
        SqlConnection vetClinicDBConnection = null;
        SqlCommand queryDB = null;
        string imgPath = String.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            vetClinicDBConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["vetClinicDBConnection"].ConnectionString);
            vetClinicDBConnection.Open();
        }

        // Загрузка изображения питомца 
        private void btnUploadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();
            openFD.Filter = "PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                imgPath = openFD.FileName.ToString();
                lblUploadImg.Text = "Загружено: " + openFD.FileName;
            }
        }



        // Загрузка данных владельца и питомца в БД
        private void btnInsert_Click(object sender, EventArgs e)
        {
            queryDB = new SqlCommand();
            byte[] images = null;
            // Получение строки изображения (иф нужен для того чтобы не выходило эксепшена)

            if (imgPath != String.Empty)
            {
                FileStream stream = new FileStream(imgPath, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(stream);
                images = reader.ReadBytes((int)stream.Length);
            }

            //Добавление в БД владельца
            string query = "INSERT INTO owner(first_name, last_name, adress, phone_number, email)" +
                 $"VALUES (N'{tbOwnerFName.Text}', N'{tbOwnerLName.Text}', N'{tbOwnerAdress.Text}', '{tbOwnerPhone.Text}', '{tbOwnerEmail.Text}');";
            queryDB = new SqlCommand(query, vetClinicDBConnection);
            queryDB.ExecuteNonQuery();


            //Получение id владельца, чтобы передать его в БД питомца

            query = "SELECT @@IDENTITY";
            queryDB = new SqlCommand(query, vetClinicDBConnection);
            string ownerid = queryDB.ExecuteScalar().ToString();

            //Добавление в БД питомца

            query = "INSERT INTO pet(pet_type, name, birthday_date, owner, photo)" +
                $"VALUES (N'{tbPetType.Text}', N'{tbPetName.Text}', N'{tbPetBday.Text}', '{ownerid}', '{images}');";
            queryDB = new SqlCommand(query, vetClinicDBConnection);
            queryDB.ExecuteNonQuery();
        }
    }
}
