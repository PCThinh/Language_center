namespace English_center
{
    partial class Course
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
            this.txtInformation = new System.Windows.Forms.GroupBox();
            this.txtLanguage = new System.Windows.Forms.ComboBox();
            this.txtStatus = new System.Windows.Forms.ComboBox();
            this.txtLevel = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpdobe = new System.Windows.Forms.DateTimePicker();
            this.txtTeachinghours = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtdesciption = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNameTeacher = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpdobs = new System.Windows.Forms.DateTimePicker();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtStatus1 = new System.Windows.Forms.ComboBox();
            this.txtLevel1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFind = new FontAwesome.Sharp.IconButton();
            this.btnCancel = new FontAwesome.Sharp.IconButton();
            this.btnSave = new FontAwesome.Sharp.IconButton();
            this.btnDelete = new FontAwesome.Sharp.IconButton();
            this.btnEdit = new FontAwesome.Sharp.IconButton();
            this.btnAdd = new FontAwesome.Sharp.IconButton();
            this.txtlanguage1 = new System.Windows.Forms.ComboBox();
            this.txtInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInformation
            // 
            this.txtInformation.Controls.Add(this.txtLanguage);
            this.txtInformation.Controls.Add(this.txtStatus);
            this.txtInformation.Controls.Add(this.txtLevel);
            this.txtInformation.Controls.Add(this.label12);
            this.txtInformation.Controls.Add(this.label14);
            this.txtInformation.Controls.Add(this.label7);
            this.txtInformation.Controls.Add(this.dtpdobe);
            this.txtInformation.Controls.Add(this.txtTeachinghours);
            this.txtInformation.Controls.Add(this.label13);
            this.txtInformation.Controls.Add(this.txtdesciption);
            this.txtInformation.Controls.Add(this.label6);
            this.txtInformation.Controls.Add(this.txtPrice);
            this.txtInformation.Controls.Add(this.label5);
            this.txtInformation.Controls.Add(this.label4);
            this.txtInformation.Controls.Add(this.txtNameTeacher);
            this.txtInformation.Controls.Add(this.label8);
            this.txtInformation.Controls.Add(this.dtpdobs);
            this.txtInformation.Controls.Add(this.txtDuration);
            this.txtInformation.Controls.Add(this.txtCourseName);
            this.txtInformation.Controls.Add(this.label3);
            this.txtInformation.Controls.Add(this.label2);
            this.txtInformation.Controls.Add(this.label1);
            this.txtInformation.Location = new System.Drawing.Point(345, 47);
            this.txtInformation.Name = "txtInformation";
            this.txtInformation.Size = new System.Drawing.Size(936, 305);
            this.txtInformation.TabIndex = 4;
            this.txtInformation.TabStop = false;
            this.txtInformation.Text = "Information";
            // 
            // txtLanguage
            // 
            this.txtLanguage.FormattingEnabled = true;
            this.txtLanguage.Items.AddRange(new object[] {
            "English",
            "French ",
            "Germany",
            "Japan"});
            this.txtLanguage.Location = new System.Drawing.Point(565, 235);
            this.txtLanguage.Name = "txtLanguage";
            this.txtLanguage.Size = new System.Drawing.Size(231, 24);
            this.txtLanguage.TabIndex = 42;
            // 
            // txtStatus
            // 
            this.txtStatus.FormattingEnabled = true;
            this.txtStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive",
            " "});
            this.txtStatus.Location = new System.Drawing.Point(108, 270);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(231, 24);
            this.txtStatus.TabIndex = 41;
            // 
            // txtLevel
            // 
            this.txtLevel.FormattingEnabled = true;
            this.txtLevel.Items.AddRange(new object[] {
            "A1",
            "A2",
            "B1",
            "B2",
            "C1",
            "C2",
            "A1-B2",
            "A2-B2",
            " "});
            this.txtLevel.Location = new System.Drawing.Point(108, 226);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(231, 24);
            this.txtLevel.TabIndex = 40;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 277);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 16);
            this.label12.TabIndex = 38;
            this.label12.Text = "Status";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(436, 243);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 16);
            this.label14.TabIndex = 37;
            this.label14.Text = "Language";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 33;
            this.label7.Text = "Level";
            // 
            // dtpdobe
            // 
            this.dtpdobe.Location = new System.Drawing.Point(565, 36);
            this.dtpdobe.Name = "dtpdobe";
            this.dtpdobe.Size = new System.Drawing.Size(231, 22);
            this.dtpdobe.TabIndex = 29;
            // 
            // txtTeachinghours
            // 
            this.txtTeachinghours.Location = new System.Drawing.Point(565, 189);
            this.txtTeachinghours.Name = "txtTeachinghours";
            this.txtTeachinghours.Size = new System.Drawing.Size(231, 22);
            this.txtTeachinghours.TabIndex = 28;
            this.txtTeachinghours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTeachinghours_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(436, 192);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 16);
            this.label13.TabIndex = 27;
            this.label13.Text = "Teaching hours";
            // 
            // txtdesciption
            // 
            this.txtdesciption.Location = new System.Drawing.Point(108, 186);
            this.txtdesciption.Name = "txtdesciption";
            this.txtdesciption.Size = new System.Drawing.Size(231, 22);
            this.txtdesciption.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Description";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(565, 138);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(231, 22);
            this.txtPrice.TabIndex = 20;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(436, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(436, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "EndDay";
            // 
            // txtNameTeacher
            // 
            this.txtNameTeacher.FormattingEnabled = true;
            this.txtNameTeacher.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.txtNameTeacher.Location = new System.Drawing.Point(565, 88);
            this.txtNameTeacher.Name = "txtNameTeacher";
            this.txtNameTeacher.Size = new System.Drawing.Size(231, 24);
            this.txtNameTeacher.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(436, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Name_Teacher";
            // 
            // dtpdobs
            // 
            this.dtpdobs.Location = new System.Drawing.Point(108, 138);
            this.dtpdobs.Name = "dtpdobs";
            this.dtpdobs.Size = new System.Drawing.Size(231, 22);
            this.dtpdobs.TabIndex = 12;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(108, 90);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(231, 22);
            this.txtDuration.TabIndex = 7;
            this.txtDuration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDuration_KeyPress);
            // 
            // txtCourseName
            // 
            this.txtCourseName.Location = new System.Drawing.Point(108, 35);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(231, 22);
            this.txtCourseName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "StartDay";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Duration";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Course Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 356);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1330, 198);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(796, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 16);
            this.label9.TabIndex = 25;
            this.label9.Text = "Status";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 16);
            this.label10.TabIndex = 26;
            this.label10.Text = "Level";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(384, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 16);
            this.label11.TabIndex = 27;
            this.label11.Text = "Language";
            // 
            // txtStatus1
            // 
            this.txtStatus1.FormattingEnabled = true;
            this.txtStatus1.Items.AddRange(new object[] {
            "Active",
            "Inactive",
            " "});
            this.txtStatus1.Location = new System.Drawing.Point(875, 15);
            this.txtStatus1.Name = "txtStatus1";
            this.txtStatus1.Size = new System.Drawing.Size(244, 24);
            this.txtStatus1.TabIndex = 29;
            this.txtStatus1.Text = "Active";
            this.txtStatus1.SelectedIndexChanged += new System.EventHandler(this.txtStatus1_SelectedIndexChanged);
            // 
            // txtLevel1
            // 
            this.txtLevel1.FormattingEnabled = true;
            this.txtLevel1.Items.AddRange(new object[] {
            "All",
            "A1",
            "A2",
            "B1",
            "B2",
            "C1",
            "C2",
            "A1-B2",
            "A2-B2",
            " "});
            this.txtLevel1.Location = new System.Drawing.Point(88, 15);
            this.txtLevel1.Name = "txtLevel1";
            this.txtLevel1.Size = new System.Drawing.Size(244, 24);
            this.txtLevel1.TabIndex = 31;
            this.txtLevel1.Text = "All";
            this.txtLevel1.SelectedIndexChanged += new System.EventHandler(this.txtLevel1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 305);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tool";
            // 
            // btnFind
            // 
            this.btnFind.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnFind.IconColor = System.Drawing.Color.Black;
            this.btnFind.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFind.Location = new System.Drawing.Point(117, 150);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCancel.IconColor = System.Drawing.Color.Black;
            this.btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancel.Location = new System.Drawing.Point(19, 150);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnSave.IconColor = System.Drawing.Color.Black;
            this.btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSave.Location = new System.Drawing.Point(117, 90);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnDelete.IconColor = System.Drawing.Color.Black;
            this.btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDelete.Location = new System.Drawing.Point(117, 33);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnEdit.IconColor = System.Drawing.Color.Black;
            this.btnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEdit.Location = new System.Drawing.Point(19, 90);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnAdd.IconColor = System.Drawing.Color.Black;
            this.btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdd.Location = new System.Drawing.Point(19, 34);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtlanguage1
            // 
            this.txtlanguage1.FormattingEnabled = true;
            this.txtlanguage1.Items.AddRange(new object[] {
            "All",
            "English",
            "French",
            "Germany",
            "Japan"});
            this.txtlanguage1.Location = new System.Drawing.Point(458, 17);
            this.txtlanguage1.Name = "txtlanguage1";
            this.txtlanguage1.Size = new System.Drawing.Size(244, 24);
            this.txtlanguage1.TabIndex = 33;
            this.txtlanguage1.Text = "All";
            this.txtlanguage1.SelectedIndexChanged += new System.EventHandler(this.txtlanguage1_SelectedIndexChanged);
            // 
            // Course
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 553);
            this.Controls.Add(this.txtlanguage1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtLevel1);
            this.Controls.Add(this.txtStatus1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtInformation);
            this.Name = "Course";
            this.Text = "Course";
            this.Load += new System.EventHandler(this.Course_Load);
            this.txtInformation.ResumeLayout(false);
            this.txtInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox txtInformation;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox txtNameTeacher;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpdobs;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtdesciption;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox txtStatus1;
        private System.Windows.Forms.ComboBox txtLevel1;
        private System.Windows.Forms.TextBox txtTeachinghours;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpdobe;
        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton btnFind;
        private FontAwesome.Sharp.IconButton btnCancel;
        private FontAwesome.Sharp.IconButton btnSave;
        private FontAwesome.Sharp.IconButton btnDelete;
        private FontAwesome.Sharp.IconButton btnEdit;
        private FontAwesome.Sharp.IconButton btnAdd;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox txtLanguage;
        private System.Windows.Forms.ComboBox txtStatus;
        private System.Windows.Forms.ComboBox txtLevel;
        private System.Windows.Forms.ComboBox txtlanguage1;
    }
}