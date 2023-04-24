using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_center
{
    internal class Course_Users
    {
        public string Courseid { get; set; }
        public string CourseName { get; set; }
        public string Duration { get; set; }
        public DateTime startday { get; set; }

        public DateTime endday { get; set; }
        public string description { get; set; }

        public string language { get; set; }
        public string NameTeacher { get; set; }
        public string price { get; set; }

        public string level { get; set;  }

        public string teachinghours { get; set; }

        public string status { get; set; }
    }
}
