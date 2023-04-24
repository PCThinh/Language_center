using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace English_center
{
    internal class ClassController
    {
        private ClassModel ClassModel = new ClassModel();
        public List<Class_Users> GetCourses()
        {
            return ClassModel.GetCourses();
        }
        public bool FindCourses1(string coursename)
        {
            return ClassModel.Find(coursename);
        }
        public string getId()
        {
            return ClassModel.AutoID();
        }
        public List<Class_Users> FindCourses(string coursename)
        {
            return ClassModel.FindCourses(coursename);
        }
        public List<Class_Users> FindLevel(string level)
        {
            return ClassModel.FindLevel(level);
        }
        public List<Class_Users> FindLanguage(string language)
        {
            return ClassModel.FindLanguage(language);
        }
        public List<Class_Users> FindStatus(string status)
        {
            return ClassModel.FindStatus(status);
        }


        public void AddUser(string Classid, string coursename, string TeacherName, string status)
        {
            Class_Users users = new Class_Users();
            users.id = Classid;
            users.NameCourse = coursename;
            users.status = status;
            users.TeacherName = TeacherName;
            ClassModel.AddCourse(users);
        }
        public void UpdateUser(string Classid, string coursename, string TeacherName, string status)
        {
            Class_Users users = new Class_Users();
            users.id = Classid;
            users.NameCourse = coursename;
            users.status = status;
            users.TeacherName = TeacherName;
            ClassModel.UpdateCourse(users);
        }
        public void DeleteUser(string Id)
        {
            ClassModel.DeleteCourse(Id);
        }

    }
}
