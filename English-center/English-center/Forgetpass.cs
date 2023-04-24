using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace English_center
{
    public partial class Forgetpass : Form
    {
        UserController userController = new UserController();
        public Forgetpass()
        {
            InitializeComponent();
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            string username=txtUserName.Text;
            string newpass = txtNew.Text;
            string conpass = txtConfirmNew.Text;
            string oldpass = txtOld.Text;
            if (username == "" || newpass == "" ||  conpass == ""|| oldpass=="")
            {
                MessageBox.Show("Please fill full the information");
                return;
            }
            else
            {
                if (userController.check(username,oldpass))
                {
                    if (newpass.Length < 6 || !Regex.IsMatch(newpass, @"^(?=.*[!@#$%^&*()_\-+={}|\\;:'""<>,.?/\[\]`~])(?=.*[A-Z])(?=.*\d)[A-Za-z\d!@#$%^&*()_\-+={}|\\;:'""<>,.?/\[\]`~]*$"))
                    {
                        MessageBox.Show("Pass must have at least one uppercase,one special characters");
                        return;
                    }
                    if (newpass == conpass)
                    {
                        userController.updatepass(username, newpass);
                        MessageBox.Show("Change Successfully");
                        SignIn sign= new SignIn();
                        this.Hide();
                        sign.Show();
                    }
                    else
                    {
                        MessageBox.Show("Password do not match");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("username or old password not valid");
                    return;
                }
            }
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.Show();
        }

        private void Forgetpass_Load(object sender, EventArgs e)
        {

        }
    }
}
