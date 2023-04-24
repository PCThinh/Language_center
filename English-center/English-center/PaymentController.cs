using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace English_center
{
    internal class PaymentController
    {
        private PaymentModel PaymentModel = new PaymentModel();
        public List<Payment_Users> GetPayments()
        {
            return PaymentModel.GetPayments();
        }
        public bool FindPayments1(string coursename)
        {
            return PaymentModel.Find(coursename);
        }
        public string getId(string datetime)
        {
            return PaymentModel.AutoID(datetime);
        }
        public List<Payment_Users> FindPayments(string name)
        {
            return PaymentModel.FindPayments(name);
        }


        public void AddPayment(string id, DateTime PaymentDate, string Paymentmethod, string coursename, string name, string price, string Paymentinfo, DateTime Duedate, string Status, string Debt, string Paid)
        {
            Payment_Users users = new Payment_Users();
            users.Paymentid = id;
            users.Paymentdate = PaymentDate;
            users.Paymentmethod = Paymentmethod;
            users.Coursename = coursename;
            users.Name = name;
            users.Price = price;
            users.Paymentinfo = Paymentinfo;
            users.Duedate = Duedate;
            users.status = Status;
            users.Debt = Debt;
            users.Paid = Paid;
            PaymentModel.AddPayment(users);
        }
        public void UpdatePayment(string id, DateTime PaymentDate, string Paymentmethod, string coursename, string name, string price, string Paymentinfo, DateTime Duedate, string Status, string Debt, string Paid)
        {
            Payment_Users users = new Payment_Users();
            users.Paymentid = id;
            users.Paymentdate = PaymentDate;
            users.Paymentmethod = Paymentmethod;
            users.Coursename = coursename;
            users.Name = name;
            users.Price = price;
            users.Paymentinfo = Paymentinfo;
            users.Duedate = Duedate;
            users.status = Status;
            users.Debt = Debt;
            users.Paid = Paid;
            PaymentModel.UpdatePayment(users);
        }
        public void DeletePayment(string Id)
        {
            PaymentModel.DeletePayment(Id);
        }

    }
}
