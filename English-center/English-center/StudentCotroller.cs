using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace English_center
{
    internal class StudentCotroller
    {
        private StudentModel studentModel = new StudentModel();
        public List<Student_Users> GetUsers()
        {
            return studentModel.GetStudents();
        }
        public bool FindUsers(string username)
        {
            return studentModel.Find(username);
        }
        public string getId()
        {
            return studentModel.AutoID();
        }
        public List<Student_Users> FindStudents(string username)
        {
            return studentModel.FindStudents(username);
        }
        public void AddUser(string id, string FullName, string Sex, DateTime dateOfBirth, string Phone, string Address,string class_name)
        {
            Student_Users users = new Student_Users();
            users.Studentid = id;
            users.Name = FullName;
            users.Sex = Sex;
            users.Address =Address ;
            users.Phone = Phone;
            users.DateOfBirth = dateOfBirth;
            users.Class_Name = class_name;
            studentModel.AddStudent(users);
        }
        public void UpdateUser(string id, string FullName, string Sex, DateTime dateOfBirth, string Phone, string Address, string class_name)
        {
            Student_Users users = new Student_Users();
            users.Studentid = id;
            users.Name = FullName;
            users.Sex = Sex;
            users.Address = Address;
            users.Phone = Phone;
            users.DateOfBirth = dateOfBirth;
            users.Class_Name = class_name;
            studentModel.UpdateStudent(users);
        }
        public void DeleteUser(string Id)
        {
            studentModel.DeleteStudent(Id);
        }

    }
}
