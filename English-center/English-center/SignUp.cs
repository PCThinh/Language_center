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

    public partial class SignUp : Form
    {
        private UserController userController = new UserController();
        private UserModel userModel = new UserModel();
        public SignUp()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string id = userController.getID();
            string userName = txtUserName.Text;
            string fullName = txtName.Text;
            DateTime dateOfBirth = dtpdob.Value;
            string phone = txtPhone.Text;
            string pass = txtPass.Text;
            string conpass = txtConpass.Text;
            string sex=txtPass.Text;
            string address = txtAddress.Text;
            if (userName == "" || fullName == "" || dateOfBirth.ToString() == "" || phone == "" || pass == "")
            {
                MessageBox.Show("Can not null");
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
                if (pass != conpass)
                {
                    MessageBox.Show("Do not match");
                    return;
                }
                    if (userController.FindUsers(userName))
                    {
                        userController.AddUser(id, fullName, userName, dateOfBirth, phone, pass,sex,address);
                        MessageBox.Show("Sign Up Sucessfully");
                        SignIn sign = new SignIn();
                        sign.Show();    
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("UserName already exists");
                    }

            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SignIn signin = new SignIn();
            this.Hide();
            signin.Show();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}