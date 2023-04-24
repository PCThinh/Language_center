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
    public partial class Forgotpassword : Form
    {
        UserController userController = new UserController();
        public Forgotpassword()
        {
            InitializeComponent();
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
    
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string phone = txtPhone.Text;
            if (phone == "")
            {
                MessageBox.Show("Please fill the phone number");
                return;
            }
            else
            {
                if (userController.checkphone(phone))
                {
                    Random r = new Random();
                    int randNum = r.Next(1000000);
                    string otp = randNum.ToString("D6");
                    userController.insert(otp,phone);
                    Otp otp1 =new Otp();
                    this.Hide();
                    otp1.Show();

                }
                else
                {
                    MessageBox.Show("Phone is not valid");
                    return;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            SignIn signin = new SignIn();
            this.Hide();
            signin.Show();
        }
    }
}
