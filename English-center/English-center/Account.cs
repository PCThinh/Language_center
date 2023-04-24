using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace English_center
{
    public partial class Account : Form
    {
        private UserController userController = new UserController();
        private string selectedID;
        public Account()
        {
            InitializeComponent();

        }
        private UserModel userModel = new UserModel();

        private void btnAdd_Click(object sender, EventArgs e)
        {

            string id = userModel.AutoID();
            string userName = txtUserName.Text;
            string fullName = txtName.Text;
            DateTime dateOfBirth = dtpDob.Value;
            string phone = txtPhone.Text;
            string pass = txtPass.Text;
            string sex = txtSex.Text;
            string address = txtAddress.Text;
            txtInformation.Enabled = true;
            txtUserName.Text = "";
            txtName.Text = "";
            dtpDob.Text = "";
            txtPhone.Text = "";
            txtPass.Text = "";
            txtPosition.Text = "";
            txtSex.Text = "";
            txtAddress.Text = "";
            txtUserName.Focus();
            btnSave.Enabled = true;
            if (userName == "" || fullName == "" || dateOfBirth.ToString() == "" || phone == "" || pass == "")
            {
                MessageBox.Show("Please fill full the information");
            }
            else
            {
                if (Regex.IsMatch(userName, "[^A-Za-z0-9 ]") || Regex.IsMatch(fullName, "[^A-Za-z0-9 ]"))
                {
                    MessageBox.Show("username or fullname can not contain special characters");
                    return;
                }
                if (pass.Length < 6 || !Regex.IsMatch(pass, @"^(?=.*[!@#$%^&*()_\-+={}|\\;:'""<>,.?/\[\]`~])(?=.*[A-Z])(?=.*\d)[A-Za-z\d!@#$%^&*()_\-+={}|\\;:'""<>,.?/\[\]`~]*$"))
                {
                    MessageBox.Show("Pass must have at least one uppercase,one special characters");
                    return;
                }
                if (userController.FindUsers(userName))
                {
                    userController.AddUser(id, fullName, userName, dateOfBirth, phone, pass,sex,address);

                    StudentdataGridView.DataSource = userController.GetUsers();
                    MessageBox.Show("Add Successfully");
                }
                else
                {
                    MessageBox.Show("UserName duplicate");
                }
            }
        }    
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xóa sinh viên", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {

                if (selectedID != null)
                {
                    userController.DeleteUser(selectedID);

                    StudentdataGridView.DataSource = userController.GetUsers();
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

        private void UserdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserdataGridView_Click(object sender, EventArgs e)
        {

        }

        private void UserdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CultureInfo provider = CultureInfo.CurrentCulture;
            if (StudentdataGridView.SelectedRows.Count > 0)
            {
                selectedID = StudentdataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtUserName.Text = StudentdataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtName.Text = StudentdataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPhone.Text = StudentdataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                dtpDob.Value = DateTime.Parse(StudentdataGridView.Rows[e.RowIndex].Cells[4].Value.ToString());
                txtPass.Text = StudentdataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (StudentdataGridView.SelectedRows.Count > 0)
            {
                txtUserName.Text = StudentdataGridView.SelectedRows[0].Cells[1].Value.ToString();
                txtName.Text = StudentdataGridView.SelectedRows[0].Cells[2].Value.ToString();
                txtPhone.Text = StudentdataGridView.SelectedRows[0].Cells[3].Value.ToString();
                dtpDob.Value = DateTime.Parse(StudentdataGridView.SelectedRows[0].Cells[4].Value.ToString());
                txtPass.Text = StudentdataGridView.SelectedRows[0].Cells[5].Value.ToString();
                StudentdataGridView.ReadOnly = true;
                txtInformation.Enabled= true;
                txtName.Focus();
                btnSave.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            StudentdataGridView.DataSource = userController.GetUsers();
            txtInformation.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selectedID != "")
            {
                string username = txtUserName.Text;
                string fullname  = txtName.Text;
                DateTime dateOfBirth = dtpDob.Value;
                string pass = txtPass.Text;
                string phone = txtPhone.Text;
                string position = txtPosition.Text;
                string sex = txtSex.Text;
                string address = txtAddress.Text;
                userController.UpdateUser(selectedID, fullname, username, dateOfBirth, phone, pass,sex,position,address);
                MessageBox.Show(selectedID);
                StudentdataGridView.DataSource = userController.GetUsers();
                MessageBox.Show("Update Successfully");
            }
            else
            {
                MessageBox.Show("Please select a student to update.");
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            txtInformation.Enabled = true;
            txtName.Enabled = false;
            txtPass.Enabled = false;
            dtpDob.Enabled= false;
            txtPhone.Enabled = false;
            txtSex.Enabled = false;
            txtAddress.Enabled = false;
            txtName.Text = "";
            dtpDob.Text = "";
            txtPhone.Text = "";
            txtPass.Text = "";
            txtSex.Text = "";
            txtAddress.Text = "";
            txtUserName.Focus();
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            string username = txtUserName.Text.Trim();
            string position= txtPosition.Text.Trim();
            if (username == "" ||position=="")
            {
                MessageBox.Show("Please fill username or position to find");
            }
            else
            {
                if (userController.FindUsers(username))
                {
                    MessageBox.Show("Account not valid");
                    StudentdataGridView.DataSource = userController.FindAccounts(username,position);
                }
                else
                {
                    StudentdataGridView.DataSource = userController.FindAccounts(username,position);
                    MessageBox.Show("Successfully");
                }
                {

                }
            }
       
    }
        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void Account_Load(object sender, EventArgs e)
        {
            StudentdataGridView.DataSource = userController.GetUsers();
            txtInformation.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
