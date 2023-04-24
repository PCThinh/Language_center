using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_center
{
    internal class Payment_Users
    {
        public string Paymentid { get;    set; }
        public DateTime Paymentdate { get; set; }
        public string Paymentmethod { get; set; }
        public string Coursename { get; set; }

        public string Name { get; set; }
        public string Price { get; set; }

        public string Paymentinfo { get; set; }
        public DateTime Duedate{ get; set; }
        public string status { get; set; }

        public string Debt { get; set;  }

        public string Paid { get; set; }

    }
}
