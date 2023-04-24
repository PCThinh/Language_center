using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_center
{
    internal class UserController
    {
        private UserModel userModel = new UserModel();
        public List<Users> GetUsers()
        {
            return userModel.GetAccounts();
        }
        public bool FindUsers(string username)
        {
            return userModel.Find(username);
        }
        public void updatepass(string username,string password)
        {
            userModel.updatepass(password, username);
        }
        public String getID()
        {
            return userModel.AutoID();
        }
        public List<Users> FindAccounts(string username,string position1)
        {
            return userModel.FindAccount(username,position1);
        }
        public bool check(string username,string pass)
        {
            return userModel.check(username, pass);
        }
        public void AddUser(string id, string FullName, string UserName, DateTime dateOfBirth, string Phone, string pass,string sex,string address)
        {
            Users users = new Users();
            users.Userid = id;
            users.UserName = UserName;
            users.FullName = FullName;
            users.DateOfBirth = dateOfBirth;
            users.Phone = Phone;
            users.Password = pass;
            users.Sex = sex;
            users.Position ="HV";
            users.Address = address;
            userModel.AddAccount(users);
        }
        public void UpdateUser(string id, string FullName, string UserName, DateTime dateOfBirth, string phone, string pass, string sex,string position,string address)
        {
            Users users = new Users();
            users.Userid = id;
            users.UserName = UserName;
            users.FullName = FullName;
            users.Phone = phone;
            users.DateOfBirth = dateOfBirth;
            users.Password = pass;
            users.Sex = sex;
            users.Position =position;
            users.Address = address;
            userModel.UpdateAccount(users);
        }
        public void DeleteUser(string Id)
        {
            userModel.DeleteAccount(Id);
        }

    }
}
