using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_center
{
    internal class StaffModel
    {
        List<Staff_Users> staffs;
        public string GetConnectionString()
        {
            staffs = new List<Staff_Users>();
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
        public bool Find(string fullname,string position)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Staffs where Name=@fullname and Position=@position ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@fullname", fullname);
                command.Parameters.AddWithValue("@position", position);
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
        public List<Staff_Users> GetStaffs()
        {
            staffs = new List<Staff_Users>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Staffs";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Staff_Users users = new Staff_Users();
                    users.Staffid = reader["id"].ToString();
                    users.Name = reader["Name"].ToString();
                    users.Sex = reader["Sex"].ToString();
                    users.Address = reader["Address"].ToString();
                    users.Phone = reader["Phone"].ToString();
                    users.DateOfBirth = (DateTime)reader["Dateofbirth"];
                    users.Position = reader["Position"].ToString();
                    users.className = reader["Class_Name"].ToString();
                    staffs.Add(users);
                }

                reader.Close();
            }

            return staffs;
        }
        public List<Staff_Users> FindStaffs(string fullname1,string position)
        {
            staffs = new List<Staff_Users>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Staffs where Name=@fullname and Position=@position";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@fullname", fullname1);
                command.Parameters.AddWithValue("@position", position);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Staff_Users users = new Staff_Users();
                    users.Staffid = reader["id"].ToString();
                    users.Name = reader["Name"].ToString();
                    users.Sex = reader["Sex"].ToString();
                    users.Address = reader["Address"].ToString();
                    users.Phone = reader["Phone"].ToString();
                    users.DateOfBirth = (DateTime)reader["Dateofbirth"];
                    users.Position = reader["Position"].ToString();
                    users.className = reader["Class_Name"].ToString();
                    staffs.Add(users);
                }

                reader.Close();
            }

            return staffs;
        }
        public void AddStaff(Staff_Users users)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "INSERT INTO Staffs (id,Name,Sex,Dateofbirth,Phone,Position,Address,Class_Name) " +
                    "VALUES (@id, @Fullname, @Sex, @dateofbirth,@Phone, @Position, @Address,@Class_Name)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", users.Staffid);
                command.Parameters.AddWithValue("@Fullname", users.Name);
                command.Parameters.AddWithValue("@Sex", users.Sex);
                command.Parameters.AddWithValue("@Phone", users.Phone);
                command.Parameters.AddWithValue("@dateOfBirth", users.DateOfBirth);
                command.Parameters.AddWithValue("@Position", users.Position);
                command.Parameters.AddWithValue("@Address", users.Address);
                command.Parameters.AddWithValue("@Class_Name", users.className);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void UpdateStaff(Staff_Users users)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "UPDATE Staffs SET Name = @FullName, Phone = @Phone, " +
                "Dateofbirth = @DateOfBirth, Sex = @Sex , Position=@Position, Address=@Address,Class_Name=@Class_Name " +
                "WHERE id = @UserId";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", users.Staffid);
                command.Parameters.AddWithValue("@Fullname", users.Name);
                command.Parameters.AddWithValue("@Sex", users.Sex);
                command.Parameters.AddWithValue("@Phone", users.Phone);
                command.Parameters.AddWithValue("@dateOfBirth", users.DateOfBirth);
                command.Parameters.AddWithValue("@Position", users.Position);
                command.Parameters.AddWithValue("@Address", users.Address);
                command.Parameters.AddWithValue("@Class_Name", users.className);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void DeleteStaff(string id)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "DELETE FROM staffs WHERE id = @UserId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public string AutoID(string position)
        {
            string id = "";
            string ms = "";
            string query= "";
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                if (position == "GV")
                {
                    query = "SELECT TOP 1 id FROM Staffs where id like 'GV%' ORDER BY id DESC ";
                }
                else
                {
                    query = "SELECT TOP 1 id FROM Staffs where id like 'AD%' ORDER BY id DESC ";
                }
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
                return position + ms;
            }

        }

    }
}
