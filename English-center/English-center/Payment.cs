using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace English_center
{
    public partial class Payment : Form
    {
        private PaymentController paymentController = new PaymentController();
        private string selectedID;
        public Payment()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime paymentdate = dtpdate.Value;
            string datetime1 = paymentdate.ToString("yyyy/MM/dd");
            string datetime = datetime1.Replace("/", "");
            string id = paymentController.getId(datetime);
            string name = txtName.Text;
            string method = txtPaymentmethod.Text;
            string coursename = txtCoursename.Text;
            string price = txtprice.Text;
            string paymentinfo = txtPaymentinfo.Text;
            txtInformation.Enabled = true;
            DateTime duedate = dtpdue.Value;
            string Paid = txtPaid.Text;
            txtName.Text = "";
            dtpdate.Text = "";
            txtName.Text = "";
            txtPaymentmethod.Text = "";
            txtPaymentinfo.Text = "";
            txtCoursename.Text = "";
            txtprice.Text = "";
            txtPaymentinfo.Text = "";
            txtName.Focus();
            txtDebt.Enabled = false;
            txtstatus.Enabled = false;
            btnSave.Enabled = true;
            if (paymentdate.ToString() == "" || name == "" || method == "" || coursename == "" || price == "" || paymentinfo == "" || duedate.ToString() == "" || Paid == "")
            {
                MessageBox.Show("Please fill full the information");
                return;
            }
            else
            {
                if (Regex.IsMatch(name, "[^A-Za-z0-9 ]") || Regex.IsMatch(name, "[^A-Za-z0-9 ]"))
                {
                    MessageBox.Show("name can not contain special characters");
                    return;
                }
                int price1 = 0;
                if (price != "")
                {
                    price1 = Int32.Parse(price);
                }
                string debt = "";
                string status = "";
                int paid = 0;
                if (Paid != "")
                {
                    paid = Int32.Parse(Paid);
                }
                if (price1 - paid == 0)
                {
                    debt = "0";
                    status = "Complete";
                }
                else if ((price1 - paid) > 0)
                {
                    debt = (price1 - paid).ToString();
                    status = "Uncomplete";
                }
                else
                {
                    debt = (price1 - paid).ToString();
                    status = "Give back";
                }
                paymentController.AddPayment(id, paymentdate, method, coursename, name, price, paymentinfo, duedate, status, debt, Paid);
            }
            dataGridView1.DataSource = paymentController.GetPayments();
            MessageBox.Show("Add Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xóa Hoa Don", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {

                if (selectedID != null)
                {
                    paymentController.DeletePayment(selectedID);

                    dataGridView1.DataSource = paymentController.GetPayments();
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

        private void Payment_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = paymentController.GetPayments();
            txtInformation.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dtpdate.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                txtPaymentmethod.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtCoursename.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txtName.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txtprice.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txtPaymentinfo.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                dtpdue.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[7].Value.ToString());
                txtstatus.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                txtDebt.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                dataGridView1.ReadOnly = true;
                txtInformation.Enabled = true;
                txtstatus.ReadOnly = true;
                txtDebt.ReadOnly=true;
                txtName.Focus();
                btnSave.Enabled = true;
                btnAdd.Enabled = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            if (name == "")
            {
                MessageBox.Show("Please choose a student to print");
                return;
            }
            PrintDocument printDocument = new PrintDocument();
            printDocument.DocumentName = "Hóa đơn";
            printDocument.DefaultPageSettings.PaperSize = new PaperSize("A6", 400, 600);
            printDocument.DefaultPageSettings.PrinterResolution.X = 300;
            printDocument.DefaultPageSettings.PrinterResolution.Y = 300;

            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            PrintDocument printDocument1 = new PrintDocument();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.Document = printDocument1;

            printPreviewDialog1.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedID= dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                dtpdate.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                txtPaymentmethod.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtCoursename.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txtName.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txtprice.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txtPaymentinfo.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                dtpdue.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells[7].Value.ToString());
                txtstatus.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                txtDebt.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                txtPaid.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                dataGridView1.ReadOnly = true;
                txtInformation.Enabled = false;
                txtstatus.ReadOnly = true;
                txtDebt.ReadOnly = true;    
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selectedID != "")
            {
                DateTime paymentdate = dtpdate.Value;
                string method = txtPaymentmethod.Text.ToString();
                string coursename= txtCoursename.Text.ToString();
                string name = txtName.Text.ToString();
                string price=txtprice.Text.ToString();
                string paymentinfo=txtPaymentinfo.Text.ToString();
                DateTime duedate = dtpdue.Value;
                string status=txtstatus.Text.ToString();
                string debt = txtDebt.Text.ToString();
                string Paid=txtPaid.Text.ToString();
                int price1 = 0;
                if (price != "")
                {
                    price1 = Int32.Parse(price);
                }
                string debt1 = "";
                string status1 = "";
                int paid = 0;
                if (Paid != "")
                {
                    paid = Int32.Parse(Paid);
                }
                if (price1 - paid == 0)
                {
                    debt1 = "0";
                    status1 = "Complete";
                }
                else if ((price1 - paid) > 0)
                {
                    debt1 = (price1 - paid).ToString();
                    status1 = "Uncomplete";
                }
                else
                {
                    debt1 = (price1 - paid).ToString();
                    status1 = "Give back";
                }
                dataGridView1.ReadOnly = true;
                txtInformation.Enabled = true;
                txtstatus.ReadOnly = true;
                txtDebt.ReadOnly = true;
                paymentController.UpdatePayment(selectedID, paymentdate, method, coursename, name, price, paymentinfo, duedate, status1, debt1, Paid);
                dataGridView1.DataSource = paymentController.GetPayments();
                MessageBox.Show("Update Successfully");
            }
            else
            {
                MessageBox.Show("Please select a student to update.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không ?", "Thoát Hóa Đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else
            {
                dataGridView1.DataSource = paymentController.GetPayments();
                txtInformation.Enabled = false;
                btnSave.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
                e.Graphics.DrawImage(Image.FromFile(@"C:\Users\TU\Desktop\Báo cáo CNPM\English-center\logo.jpg"), 30, 10, 100, 100);
                string name = txtName.Text;
                DateTime date = dtpdate.Value;
                string datetime1 = date.ToString("yyyy/MM/dd");
                string method = txtPaymentmethod.Text;
                string coursename=txtCoursename.Text;
                string price = txtprice.Text;
                string info = txtPaymentinfo.Text;
                string paid = txtPaid.Text;
                string debt = txtDebt.Text;
                string status = txtstatus.Text;
                string duedate = dtpdue.Value.ToString("yyyy/MM/dd");
                e.Graphics.DrawString("English center" , new Font("Arial", 20), Brushes.Black, 350, 50);
                e.Graphics.DrawString("Payment", new Font("Arial", 16), Brushes.Black, 400, 80);
                Pen pen = new Pen(Brushes.Black, 2);
                e.Graphics.DrawLine(pen, new Point(0, 120), new Point(e.PageBounds.Width, 120));
            // Vẽ thông tin sản phẩm
                e.Graphics.DrawString("Id: "+selectedID, new Font("Arial", 14), Brushes.Black, 50, 170);
                e.Graphics.DrawString("Date: "+datetime1, new Font("Arial", 14), Brushes.Black, 50, 200);
                e.Graphics.DrawString("Method: "+method, new Font("Arial", 14), Brushes.Black, 50, 230);
                e.Graphics.DrawString("Name: " + name, new Font("Arial", 14), Brushes.Black, 50, 260);
                e.Graphics.DrawString("Course Name: "+coursename, new Font("Arial", 14), Brushes.Black, 50, 290);
                e.Graphics.DrawString("Price: "+price, new Font("Arial", 14), Brushes.Black, 50, 320);
                e.Graphics.DrawString("Info: "+info, new Font("Arial", 14), Brushes.Black, 50, 350);
                e.Graphics.DrawString("DueDate: "+duedate, new Font("Arial", 14), Brushes.Black, 50, 380);
                e.Graphics.DrawLine(pen, new Point(0, 410), new Point(e.PageBounds.Width, 410));
            // Vẽ tổng tiền
                e.Graphics.DrawString("Paid: "+paid, new Font("Arial", 14), Brushes.Black, 550,430 );
                e.Graphics.DrawString("Stauts: " + status, new Font("Arial", 14), Brushes.Black, 550, 460);
                 e.Graphics.DrawString("debt: " + debt, new Font("Arial", 14), Brushes.Black, 550, 490);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            txtInformation.Enabled = true;
            dtpdate.Enabled = false;
            txtCoursename.Enabled = false;
            txtDebt.Enabled = false;
            txtPaid.Enabled = false;
            txtPaymentmethod.Enabled = false;
            txtprice.Enabled = false;
            txtstatus.Enabled = false;
            dtpdue.Enabled = false;
            txtName.Enabled = true;
            string name = txtName.Text;
            if (name == "")
            {
                MessageBox.Show("Please choose a student to find");
                return;
            }
            else
            {
                if (paymentController.FindPayments1(name))
                {
                    dataGridView1.DataSource=paymentController.FindPayments(name);
                }
                else
                {
                    MessageBox.Show("Student not valid");
                    dataGridView1.DataSource = paymentController.FindPayments(name);
                }
            }
        }

        private void txtprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (   e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Controls.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Controls.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
    }
