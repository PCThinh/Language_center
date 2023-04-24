using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace English_center
{
    public partial class Otp : Form
    {
        UserController userController = new UserController();
        public Otp()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Forgotpassword forgotpassword= new Forgotpassword();
            this.Hide();
            forgotpassword.Show();
        }

        private void btnverify_Click(object sender, EventArgs e)
        {
            string otp = txtotp.Text;
            if (otp == "")
            {
                MessageBox.Show("Please fill otp");
                return;
            }
            else
            {
                //if(userController.checkforgot())
            }
        }
    }
}
