namespace VetClinicApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvOwners = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.tbPetType = new System.Windows.Forms.TextBox();
            this.lblUploadImg = new System.Windows.Forms.Label();
            this.btnResetData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbOwnerPhone = new System.Windows.Forms.MaskedTextBox();
            this.tbOwnerEmail = new System.Windows.Forms.TextBox();
            this.tbPetBday = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbOwnerLName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbOwnerFName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbOwnerAdress = new System.Windows.Forms.TextBox();
            this.tbPetName = new System.Windows.Forms.TextBox();
            this.btnUploadImg = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOwners)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(200, 40);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1228, 650);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1220, 602);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Создать посетителя";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvOwners);
            this.groupBox2.Location = new System.Drawing.Point(18, 327);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1183, 254);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // dgvOwners
            // 
            this.dgvOwners.AllowUserToAddRows = false;
            this.dgvOwners.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOwners.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOwners.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOwners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOwners.Location = new System.Drawing.Point(19, 19);
            this.dgvOwners.Name = "dgvOwners";
            this.dgvOwners.Size = new System.Drawing.Size(1142, 215);
            this.dgvOwners.TabIndex = 5;
            this.dgvOwners.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOwners_CellValueChanged);
            this.dgvOwners.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvOwners_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnInsert);
            this.groupBox1.Controls.Add(this.tbPetType);
            this.groupBox1.Controls.Add(this.lblUploadImg);
            this.groupBox1.Controls.Add(this.btnResetData);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbOwnerPhone);
            this.groupBox1.Controls.Add(this.tbOwnerEmail);
            this.groupBox1.Controls.Add(this.tbPetBday);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbOwnerLName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbOwnerFName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbOwnerAdress);
            this.groupBox1.Controls.Add(this.tbPetName);
            this.groupBox1.Controls.Add(this.btnUploadImg);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(18, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1183, 302);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(219, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Данные владельца";
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsert.Location = new System.Drawing.Point(1078, 264);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(83, 23);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = "Создать";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // tbPetType
            // 
            this.tbPetType.Location = new System.Drawing.Point(740, 64);
            this.tbPetType.Name = "tbPetType";
            this.tbPetType.Size = new System.Drawing.Size(242, 20);
            this.tbPetType.TabIndex = 1;
            // 
            // lblUploadImg
            // 
            this.lblUploadImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUploadImg.AutoSize = true;
            this.lblUploadImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUploadImg.Location = new System.Drawing.Point(20, 261);
            this.lblUploadImg.Name = "lblUploadImg";
            this.lblUploadImg.Size = new System.Drawing.Size(25, 24);
            this.lblUploadImg.TabIndex = 3;
            this.lblUploadImg.Text = "...";
            // 
            // btnResetData
            // 
            this.btnResetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetData.Location = new System.Drawing.Point(962, 264);
            this.btnResetData.Name = "btnResetData";
            this.btnResetData.Size = new System.Drawing.Size(110, 23);
            this.btnResetData.TabIndex = 6;
            this.btnResetData.Text = "Очистить поля";
            this.btnResetData.UseVisualStyleBackColor = true;
            this.btnResetData.Click += new System.EventHandler(this.btnResetData_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Номер телефона";
            // 
            // tbOwnerPhone
            // 
            this.tbOwnerPhone.Location = new System.Drawing.Point(329, 64);
            this.tbOwnerPhone.Mask = "+7&&&&&&&&&&&&&&";
            this.tbOwnerPhone.Name = "tbOwnerPhone";
            this.tbOwnerPhone.Size = new System.Drawing.Size(242, 20);
            this.tbOwnerPhone.TabIndex = 4;
            this.tbOwnerPhone.TextChanged += new System.EventHandler(this.tbOwnerPhone_TextChanged);
            // 
            // tbOwnerEmail
            // 
            this.tbOwnerEmail.Location = new System.Drawing.Point(329, 212);
            this.tbOwnerEmail.Name = "tbOwnerEmail";
            this.tbOwnerEmail.Size = new System.Drawing.Size(242, 20);
            this.tbOwnerEmail.TabIndex = 1;
            // 
            // tbPetBday
            // 
            this.tbPetBday.Location = new System.Drawing.Point(740, 137);
            this.tbPetBday.Mask = "00/00/0000";
            this.tbPetBday.Name = "tbPetBday";
            this.tbPetBday.Size = new System.Drawing.Size(242, 20);
            this.tbPetBday.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(629, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Дата рождения";
            // 
            // tbOwnerLName
            // 
            this.tbOwnerLName.Location = new System.Drawing.Point(329, 137);
            this.tbOwnerLName.Name = "tbOwnerLName";
            this.tbOwnerLName.Size = new System.Drawing.Size(242, 20);
            this.tbOwnerLName.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(220, 216);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Электронная почта";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(628, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "Данные питомца";
            // 
            // tbOwnerFName
            // 
            this.tbOwnerFName.Location = new System.Drawing.Point(329, 99);
            this.tbOwnerFName.Name = "tbOwnerFName";
            this.tbOwnerFName.Size = new System.Drawing.Size(242, 20);
            this.tbOwnerFName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Фамилия";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(629, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Имя";
            // 
            // tbOwnerAdress
            // 
            this.tbOwnerAdress.Location = new System.Drawing.Point(329, 175);
            this.tbOwnerAdress.Name = "tbOwnerAdress";
            this.tbOwnerAdress.Size = new System.Drawing.Size(242, 20);
            this.tbOwnerAdress.TabIndex = 1;
            // 
            // tbPetName
            // 
            this.tbPetName.Location = new System.Drawing.Point(740, 99);
            this.tbPetName.Name = "tbPetName";
            this.tbPetName.Size = new System.Drawing.Size(242, 20);
            this.tbPetName.TabIndex = 1;
            // 
            // btnUploadImg
            // 
            this.btnUploadImg.Location = new System.Drawing.Point(740, 175);
            this.btnUploadImg.Name = "btnUploadImg";
            this.btnUploadImg.Size = new System.Drawing.Size(104, 23);
            this.btnUploadImg.TabIndex = 2;
            this.btnUploadImg.Text = "Загрузить фото";
            this.btnUploadImg.UseVisualStyleBackColor = true;
            this.btnUploadImg.Click += new System.EventHandler(this.btnUploadImg_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Адрес";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(629, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Вид";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Location = new System.Drawing.Point(4, 44);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1220, 602);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Карточка питомца";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.dataGridView2);
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Location = new System.Drawing.Point(18, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1183, 550);
            this.groupBox4.TabIndex = 37;
            this.groupBox4.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(36, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(350, 29);
            this.label21.TabIndex = 36;
            this.label21.Text = "Медицинская карта питомца";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(41, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 167);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1008, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "ID:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(337, 141);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "label13";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(968, 502);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 34;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(226, 141);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "Дата рождения: ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(36, 269);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(127, 29);
            this.label13.TabIndex = 30;
            this.label13.Text = "Прививки";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(226, 178);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 13);
            this.label17.TabIndex = 26;
            this.label17.Text = "Хозяин: ";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(226, 217);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(44, 13);
            this.label19.TabIndex = 24;
            this.label19.Text = "Адрес: ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1035, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 33;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1060, 502);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 35;
            this.button1.Text = "Показать";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(337, 217);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 13);
            this.label20.TabIndex = 23;
            this.label20.Text = "label13";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(337, 178);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 13);
            this.label18.TabIndex = 25;
            this.label18.Text = "label13";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(605, 269);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 29);
            this.label14.TabIndex = 29;
            this.label14.Text = "Услуги";
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 44);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1220, 602);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Врачи";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(41, 315);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(528, 170);
            this.dataGridView1.TabIndex = 31;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(610, 315);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(528, 170);
            this.dataGridView2.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(335, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 29);
            this.label10.TabIndex = 29;
            this.label10.Text = "Имя";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label22.Location = new System.Drawing.Point(224, 80);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 29);
            this.label22.TabIndex = 30;
            this.label22.Text = "Вид";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1228, 650);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VetClinicApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOwners)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblUploadImg;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUploadImg;
        private System.Windows.Forms.TextBox tbPetName;
        private System.Windows.Forms.TextBox tbOwnerLName;
        private System.Windows.Forms.TextBox tbOwnerEmail;
        private System.Windows.Forms.TextBox tbOwnerAdress;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPetType;
        private System.Windows.Forms.TextBox tbOwnerFName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.MaskedTextBox tbPetBday;
        private System.Windows.Forms.MaskedTextBox tbOwnerPhone;
        private System.Windows.Forms.DataGridView dgvOwners;
        private System.Windows.Forms.Button btnResetData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label10;
    }
}

