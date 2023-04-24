using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace English_center
{
    internal class CourseController
    {
        private CourseModel CourseModel = new CourseModel();
        public List<Course_Users> GetCourses()
        {
            return CourseModel.GetCourses();
        }
        public bool FindCourses1(string coursename)
        {
            return CourseModel.Find(coursename);
        }
        public string getId()
        {
            return CourseModel.AutoID();
        }
        public List<Course_Users> FindCourses(string coursename)
        {
            return CourseModel.FindCourses(coursename);
        }
        public List<Course_Users> FindLevel(string level)
        {
            return CourseModel.FindLevel(level);
        }
        public List<Course_Users> FindLanguage(string language)
        {
            return CourseModel.FindLanguage(language);
        }
        public List<Course_Users> FindStatus(string status)
        {
            return CourseModel.FindStatus(status);
        }


        public void AddUser(string Courseid, string coursename, string Duration, DateTime startday,DateTime endday, string Description, string Language,string NameTeacher,string price,string level,string teachinghours,string status)
        {
            Course_Users users = new Course_Users();
            users.Courseid = Courseid;
            users.CourseName = coursename;
            users.Duration = Duration;
            users.startday = startday;
            users.endday = endday;
            users.description = Description;
            users.language = Language;
            users.NameTeacher = NameTeacher;
            users.price = price;
            users.level = level;
            users.teachinghours = teachinghours;
            users.status = status;
            CourseModel.AddCourse(users);
        }
        public void UpdateUser(string Courseid, string coursename, string Duration, DateTime startday, DateTime endday, string Description, string Language, string NameTeacher, string price, string level, string teachinghours, string status)
        {
            Course_Users users = new Course_Users();
            users.Courseid = Courseid;
            users.CourseName = coursename;
            users.Duration = Duration;
            users.startday = startday;
            users.endday = endday;
            users.description = Description;
            users.language = Language;
            users.NameTeacher = NameTeacher;
            users.price = price;
            users.level = level;
            users.teachinghours = teachinghours;
            users.status = status;
            CourseModel.UpdateCourse(users);
        }
        public void DeleteUser(string Id)
        {
            CourseModel.DeleteCourse(Id);
        }

    }
}
