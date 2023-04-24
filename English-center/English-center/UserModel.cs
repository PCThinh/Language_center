using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace English_center
{
    internal class UserModel
    {
        List<Users> accounts;
        public string GetConnectionString()
        {
            accounts = new List<Users>();
            SqlConnectionStringBuilder builder;

            builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
            builder["Data Source"] = "LAPTOP-N2TDJQTT\\MSQL";
            builder.UserID = "LAPTOP-N2TDJQTT\\ADMIN";
            builder["integrated Security"] = true;
            builder["Initial Catalog"] = "English_center";
            Console.WriteLine(builder.ConnectionString);
            builder["Password"] = "";
            Console.Write(builder.ConnectionString);
            return builder.ConnectionString;
        }
        


        public void updatepass(string password,string username1)
        {
             string query = "UPDATE Users SET password = @password " + "WHERE username = @Name";
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@Name", username1);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public bool Find(string username) { 
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Users where username=@username ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    return false;
                }
                else
                {
                    reader.Close();
                    return true;
                   
                }
            }
        }
        public bool check(string username,string pass)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString())) { 
            string query = "SELECT * FROM Users where username=@username and password=@password ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", pass);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                reader.Close();
                return true;
                
            }
            else
            {
                reader.Close();
                return false;
                
            }
        }
    }


        public List<Users> GetAccounts()
        {
            accounts = new List<Users>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Users";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Users users = new Users();
                    users.Userid = reader["id"].ToString();
                    users.UserName = reader["username"].ToString();
                    users.FullName = reader["fullName"].ToString();
                    users.Phone = reader["phone"].ToString();
                    users.DateOfBirth = (DateTime)reader["Dateofbirth"];
                    users.Password = reader["password"].ToString(); ;
                    users.Position = reader["position"].ToString();
                    users.Sex = reader["sex"].ToString();
                    users.Address = reader["address"].ToString();
                    accounts.Add(users);
                }

                reader.Close();
            }

            return accounts;
        }
        public List<Users> FindAccount(string username1,string position1)
        {
            accounts = new List<Users>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Users where username=@username and position=@position";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username1);
                command.Parameters.AddWithValue("@position", position1);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Users users = new Users();
                    users.Userid = reader["id"].ToString();
                    users.UserName = reader["username"].ToString();
                    users.FullName = reader["fullName"].ToString();
                    users.Phone = reader["phone"].ToString();
                    users.DateOfBirth = (DateTime)reader["Dateofbirth"];
                    users.Password = reader["password"].ToString();
                    users.Position = reader["position"].ToString();
                    users.Sex = reader["sex"].ToString();
                    users.Address = reader["address"].ToString();
                    accounts.Add(users);
                }

                reader.Close();
            }


            return accounts;
        }
        public void AddAccount(Users users)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "INSERT INTO Users (id,username,fullname,phone,dateofbirth,password,position,sex,address) " +
                    "VALUES (@id, @username, @FullName, @Phone, @DateOfBirth, @password,@position,@sex,@address)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", users.Userid);
                command.Parameters.AddWithValue("@username", users.UserName);
                command.Parameters.AddWithValue("@FullName", users.FullName);
                command.Parameters.AddWithValue("@Phone", users.Phone);
                command.Parameters.AddWithValue("@DateOfBirth",users.DateOfBirth);
                command.Parameters.AddWithValue("@password", users.Password);
                command.Parameters.AddWithValue("@position", users.Position);
                command.Parameters.AddWithValue("@sex", users.Sex);
                command.Parameters.AddWithValue("@address", users.Address);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void UpdateAccount(Users users)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "UPDATE Users SET userName = @UserName, fullname = @FullName, phone = @Phone, " +
                "dateofbirth = @DateOfBirth, password = @password, position= @position, sex= @sex, address= @address " +
                "WHERE id = @UserId";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", users.Userid);
                command.Parameters.AddWithValue("@Username", users.UserName);
                command.Parameters.AddWithValue("@FullName", users.FullName);
                command.Parameters.AddWithValue("@Phone", users.Phone);
                command.Parameters.AddWithValue("@DateOfBirth", users.DateOfBirth);
                command.Parameters.AddWithValue("@password", users.Password);
                command.Parameters.AddWithValue("@position", users.Position);
                command.Parameters.AddWithValue("@sex", users.Sex);
                command.Parameters.AddWithValue("@address", users.Address);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void DeleteAccount(string id)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "DELETE FROM Users WHERE id = @UserId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public string AutoID()
        {
            string id = null;
            string ms = null;
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT TOP 1 id FROM Users ORDER BY id DESC";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                        id = reader.GetString(0).Trim();
                        int id1 = Int32.Parse(id.Substring(id.Length - 4));
                        if (id1 < 10)
                        {
                            ms = "000" + (id1 + 1).ToString();
                        }
                        else if (id1 < 100)
                        {
                            ms = "00" + (id1 + 1).ToString();
                        }
                        else
                        {
                            ms = "0" + (id1 + 1).ToString();
                        }
                    }
                    else
                    {
                        ms = "0000";
                    }
                    reader.Close();
                return "acc" + ms;
            }

        }

    }
}
