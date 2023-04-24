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
    public partial class Staff : Form
    {
        private StaffController staffController = new StaffController();
        private string selectedID;
        public Staff()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string position = txtPosition.Text;
            string id = staffController.getId(position);
            string name = txtName.Text;
            DateTime dateOfBirth = dtpdob.Value;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            string class_name = txtClassName.Text;
            string sex = txtSex.Text;
            txtInformation.Enabled = true;
            txtName.Text = "";
            dtpdob.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtPosition.Text = "";
            txtSex.Text = "";
            txtName.Focus();
            btnSave.Enabled = true;
            if (name == "" || phone == "" || dateOfBirth.ToString() == "" || address == "" || class_name == "" || sex == "" || position == "")
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
                if (position == "GV")
                {
                    staffController.AddUser(id, name, sex, dateOfBirth, phone, address, position, class_name);
                }
                else
                {
                    staffController.AddUser(id, name, sex, dateOfBirth, phone, address, position, "");
                }
                dataGridView1.DataSource = staffController.GetUsers();
                MessageBox.Show("Add Successfully");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xóa Nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {

                if (selectedID != null)
                {
                    staffController.DeleteUser(selectedID);

                    dataGridView1.DataSource = staffController.GetUsers();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string position = txtPosition.Text;
                if (position == "AD")
                {
                    txtClassName.Text = "";
                    txtClassName.Enabled = false;
                }
                else
                {
                    txtClassName.Enabled = true;
                }
                txtName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtAddress.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtPhone.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                dtpdob.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
                txtName.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txtSex.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                dataGridView1.ReadOnly = true;
                txtInformation.Enabled = true;
                txtName.Focus();
                btnSave.Enabled = true;
                btnAdd.Enabled = true;
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
                string class_name = txtName.Text;
                string sex = txtSex.Text;
                string position = txtPosition.Text;
                if (position == "GV") {
                    staffController.UpdateUser(selectedID, name, sex, dateOfBirth, phone, address, position, class_name);
                }
                else
                {
                    txtClassName.Enabled = false;
                    txtClassName.Text = "";
                    staffController.UpdateUser(selectedID, name, sex, dateOfBirth, phone, address, position,"");
                }
                dataGridView1.DataSource = staffController.GetUsers();
                MessageBox.Show("Update Successfully");
            }
            else
            {
                MessageBox.Show("Please select a student to update.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không ?", "Thoát Nhân Viên", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else
            {
                dataGridView1.DataSource = staffController.GetUsers();
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
            txtName.Enabled = true;
            txtSex.Enabled = false;
            txtClassName.Enabled = false;
            txtName.Focus();
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            string username = txtName.Text.Trim();
            string position=txtPosition.Text.Trim();
            if (username == ""||position=="")
            {
                MessageBox.Show("Please fill username and position to find");
            }
            else
            {   
                if (staffController.FindUsers(username,position))
                {
                    MessageBox.Show("Staff not valid");
                    dataGridView1.DataSource = staffController.FindStaffs(username,position);
                }
                else
                {
                    dataGridView1.DataSource = staffController.FindStaffs(username, position);
                    MessageBox.Show("Successfully");
                }
                {

                }
            }
        }

        private void Staff_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = staffController.GetUsers();
            txtInformation.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
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
                txtClassName.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtSex.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtPosition.Text= dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
