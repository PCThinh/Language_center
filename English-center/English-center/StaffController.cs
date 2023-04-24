using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace English_center
{
    internal class StaffController
    {
        private StaffModel StaffModel = new StaffModel();
        public List<Staff_Users> GetUsers()
        {
            return StaffModel.GetStaffs();
        }
        public bool FindUsers(string username,string positon)
        {
            return StaffModel.Find(username,positon);
        }
        public string getId(string position)
        {
            return StaffModel.AutoID(position);
        }
        public List<Staff_Users> FindStaffs(string username,string position)
        {
            return StaffModel.FindStaffs(username,position);
        }
        public void AddUser(string id, string FullName, string Sex, DateTime dateOfBirth, string Phone, string Address,string Position,string classname)
        {
            Staff_Users users = new Staff_Users();
            users.Staffid = id;
            users.Name = FullName;
            users.Sex = Sex;
            users.Address =Address ;
            users.Phone = Phone;
            users.DateOfBirth = dateOfBirth;
            users.Position = Position;
            users.className = classname;
            StaffModel.AddStaff(users);
        }
        public void UpdateUser(string id, string FullName, string Sex, DateTime dateOfBirth, string Phone, string Address, string Position,string classname)
        {
            Staff_Users users = new Staff_Users();
            users.Staffid = id;
            users.Name = FullName;
            users.Sex = Sex;
            users.Address = Address;
            users.Phone = Phone;
            users.DateOfBirth = dateOfBirth;
            users.Position = Position;
            users.className = classname;
            StaffModel.UpdateStaff(users);
        }
        public void DeleteUser(string Id)
        {
            StaffModel.DeleteStaff(Id);
        }

    }
}
