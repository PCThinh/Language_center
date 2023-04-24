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
    public partial class Resetpass : Form
    {
        public Resetpass()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Otp otp= new Otp();
            this.Hide();
            otp.Show();
        }

        private void btnchange_Click(object sender, EventArgs e)
        {
            UserController userController = new UserController();
        }
    }
}
