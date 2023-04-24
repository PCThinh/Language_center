using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace English_center
{
    public partial class Student : Form
    {
        private StudentCotroller studentController = new StudentCotroller();
        private string selectedID;
        public Student()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = studentController.getId();
            string name = txtName.Text;
            DateTime dateOfBirth = dtpdob.Value;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            string class_name = txtClassName.Text;
            string sex=txtSex.Text;
            txtInformation.Enabled = true;
            txtName.Text = "";
            dtpdob.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtClassName.Text = "";
            txtSex.Text = "";
            txtName.Focus();
            btnSave.Enabled = true;
            if (name == "" || phone == "" || dateOfBirth.ToString() == "" || address == "" || class_name == ""||sex=="")
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
                    studentController.AddUser(id, name, sex, dateOfBirth, phone, address,class_name);

                    dataGridView1.DataSource = studentController.GetUsers();
                    MessageBox.Show("Add Successfully");
            }
        }

        private void Student_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = studentController.GetUsers();
            txtInformation.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xóa sinh viên", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {

                if (selectedID != null)
                {
                    studentController.DeleteUser(selectedID);

                    dataGridView1.DataSource = studentController.GetUsers();
                }
                else
                {
                    MessageBox.Show("Please select a account to delete.");
                }
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                dtpdob.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                txtClassName.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtSex.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtAddress.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtPhone.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                dtpdob.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
                txtClassName.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txtSex.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                dataGridView1.ReadOnly = true;
                txtInformation.Enabled = true;
                txtName.Focus();
                btnSave.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không ?", "Thoát Sinh viên", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else
            {
                dataGridView1.DataSource = studentController.GetUsers();
                txtInformation.Enabled = false;
                btnSave.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            txtInformation.Enabled = true;
            txtPhone.Enabled = false;
            dtpdob.Enabled = false;
            txtAddress.Enabled = false;
            txtClassName.Enabled = false;
            txtSex.Enabled = false;
            txtName.Focus();
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            string username = txtName.Text.Trim();
            if (username == "")
            {
                MessageBox.Show("Please fill username to find");
            }
            else
            {
                if (studentController.FindUsers(username))
                {
                    MessageBox.Show("Student not valid");
                }
                else
                {
                    dataGridView1.DataSource = studentController.FindStudents(username);
                    MessageBox.Show("Successfully");
                }
                {

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selectedID != "")
            {
                string name = txtName.Text;
                DateTime dateOfBirth = dtpdob.Value;
                string phone = txtPhone.Text;
                string address = txtAddress.Text;
                string class_name = txtClassName.Text;
                string sex = txtSex.Text;
                studentController.UpdateUser(selectedID, name, sex, dateOfBirth, phone, address, class_name);

                dataGridView1.DataSource = studentController.GetUsers();
                MessageBox.Show("Update Successfully");
            }
            else
            {
                MessageBox.Show("Please select a student to update.");
            }
        }
    }
}
