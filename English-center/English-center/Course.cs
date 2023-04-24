using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace English_center
{
    public partial class Course : Form
    {
        private CourseController courseController = new CourseController();
        private string selectedID;
        public Course()
        {
            InitializeComponent();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string language = txtlanguage1.Text.Trim();
            if (language == "All")
            {
                dataGridView1.DataSource = courseController.GetCourses();
            }
            else
            {
                dataGridView1.DataSource = courseController.FindLanguage(language);
                MessageBox.Show(language);
            }
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            //string name = txtCourseName.Text;
            //string id = courseController.getId();
            //DateTime startday = dtpdobs.Value;
            //DateTime enddday = dtpdobe.Value;
            //int duration = Int32.Parse(txtDuration.Text);
            //string nameteacher = txtNameTeacher.Text;
            //int price = Int32.Parse(txtPrice.Text);
            //string description = txtdesciption.Text;
            //string level = txtLevel1.Text;
            //int teachinghours = Int32.Parse(txtTeachinghours.Text);
            //string language=txtLanguage1.Text;
            //string status = txtStatus1.Text;
            //txtInformation.Enabled = true;
            //txtCourseName.Text = "";
            //dtpdobs.Text = "";
            //dtpdobs.Text = "";
            //txtDuration.Text = "";
            //txtNameTeacher.Text = "";
            //txtPrice.Text = "";
            //txtdesciption.Text= "";
            //txtTeachinghours.Text = "";
            //txtCourseName.Focus();
            //btnSave.Enabled = true;
            //if (name == ""  || startday.ToString() == "" || enddday.ToString() == "" || duration.ToString() == "" || nameteacher == "" || price.ToString() == "" || description == ""||teachinghours.ToString()==""||language=="")
            //{
            //    MessageBox.Show("Please fill full the information");
            //}
            //else
            //{
            //    if (Regex.IsMatch(name, "[^A-Za-z0-9 ]") || Regex.IsMatch(name, "[^A-Za-z0-9 ]"))
            //    {
            //        MessageBox.Show("name can not contain special characters");
            //        return;
            //    }
            //    courseController.AddUser(id, name, duration, startday, enddday, description,language,nameteacher,price,level,teachinghours,status) ;
            //    dataGridView1.DataSource = courseController.GetCourses();
            //    MessageBox.Show("Add Successfully");
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCourseName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDuration.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                dtpdobs.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                dtpdobe.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                txtdesciption.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtLanguage.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtNameTeacher.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtLevel.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtTeachinghours.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                txtStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void Course_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = courseController.GetCourses();
            txtInformation.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xóa Khóa học", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {

                if (selectedID != null)
                {
                    courseController.DeleteUser(selectedID);

                    dataGridView1.DataSource = courseController.GetCourses();
                }
                else
                {
                    MessageBox.Show("Please select a course to delete.");
                }
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtCourseName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtDuration.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                dtpdobs.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                dtpdobe.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
                txtdesciption.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txtLanguage.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                txtNameTeacher.Text= dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                txtPrice.Text= dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                txtLevel.Text= dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                txtTeachinghours.Text= dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                txtStatus.Text= dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                dataGridView1.ReadOnly = true;
                txtInformation.Enabled = true;
                txtCourseName.Focus();
                btnSave.Enabled = true;
                btnAdd.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selectedID != "")
            {
                string name = txtCourseName.Text;
                DateTime startday = dtpdobs.Value;
                DateTime enddday = dtpdobe.Value;
                string duration = txtDuration.Text.ToString();
                string nameteacher = txtNameTeacher.Text;
                string price = txtPrice.Text.ToString();       
                string description = txtdesciption.Text.ToString();
                string level = txtLevel.Text;
                string teachinghours = txtTeachinghours.Text.ToString();
                string language = txtLanguage.Text;
                string status = txtStatus1.Text;
                courseController.UpdateUser(selectedID, name, duration, startday, enddday, description, language, nameteacher, price, level, teachinghours, status);
                dataGridView1.DataSource = courseController.GetCourses();
                MessageBox.Show("Update Successfully");
            }
            else
            {
                MessageBox.Show("Please select a student to update.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không ?", "Thoát Khóa học", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Main main= new Main();
                main.Show();
                this.Hide();
            }
            else
            {
                dataGridView1.DataSource = courseController.GetCourses();
                txtInformation.Enabled = false;
                btnSave.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            txtInformation.Enabled = true;
            dtpdobs.Enabled = false;
            dtpdobe.Enabled = false;
            txtDuration.Enabled = false;
            txtdesciption.Enabled = false;
            txtNameTeacher.Enabled = false;
            txtPrice.Enabled = false;
            txtTeachinghours.Enabled = false;
            txtLanguage.Enabled = false;
            txtStatus.Enabled = false;
            txtLevel.Enabled=false;
            txtCourseName.Focus();
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            string coursename = txtCourseName.Text.Trim();
            if (coursename=="")
            {
                MessageBox.Show("Please fill coursename to find");
            }
            else
            {
                if (courseController.FindCourses1(coursename))
                {
                    MessageBox.Show("Course not valid");
                    dataGridView1.DataSource = courseController.FindCourses(coursename);
                }
                else
                {
                    dataGridView1.DataSource = courseController.FindCourses(coursename);
                    MessageBox.Show("Successfully");
                }
                {


                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtCourseName.Text;
            string id = courseController.getId();
            DateTime startday = dtpdobs.Value;
            DateTime enddday = dtpdobe.Value;
            string duration = txtDuration.Text;
            string nameteacher = txtNameTeacher.Text;
            string price = txtPrice.Text;
            string description = txtdesciption.Text;
            string level = txtLevel.Text;
            string teachinghours = txtTeachinghours.Text;
            string language = txtLanguage.Text;
            string status = txtStatus.Text;
            txtInformation.Enabled = true;
            txtCourseName.Text = "";
            dtpdobs.Text = "";
            dtpdobs.Text = "";
            txtDuration.Text = "";
            txtNameTeacher.Text = "";
            txtPrice.Text = "";
            txtdesciption.Text = "";
            txtTeachinghours.Text = "";
            txtCourseName.Focus();
            btnSave.Enabled = true;
            if (name == "" || startday.ToString() == "" || enddday.ToString() == "" || duration.ToString() == "" || nameteacher == "" || price.ToString() == "" || description == "" || teachinghours.ToString() == "" || language == "")
            {
                MessageBox.Show("Please fill full the information");
            }
            else
            {
                if (Regex.IsMatch(name, "[^A-Za-z0-9 ]") || Regex.IsMatch(name, "[^A-Za-z0-9 ]"))
                {
                    MessageBox.Show("name can not contain special characters");
                    return;
                }
                courseController.AddUser(id, name, duration, startday, enddday, description, language, nameteacher, price, level, teachinghours, status);
                dataGridView1.DataSource = courseController.GetCourses();
                MessageBox.Show("Add Successfully");
            }
        }

        private void txtDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtTeachinghours_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtLevel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string level = txtLevel1.Text.Trim();
            if (level == "All")
            {
                dataGridView1.DataSource = courseController.GetCourses();
            }
            else
            {
                dataGridView1.DataSource = courseController.FindLevel(level);
            }
        }

        private void txtStatus1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = txtStatus1.Text.Trim();
                dataGridView1.DataSource = courseController.FindStatus(status);
        }

        private void txtlanguage1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string language = txtlanguage1.Text.Trim();
            if (language == "All")
            {
                dataGridView1.DataSource = courseController.GetCourses();
            }
            else
            {
                MessageBox.Show(language);
                dataGridView1.DataSource = courseController.FindLanguage(language);
            }
        }
    }
}

