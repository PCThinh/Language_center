using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_center
{
    internal class StudentModel
    {
        List<Student_Users> students;
        public string GetConnectionString()
        {
            students = new List<Student_Users>();
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
        public bool Find(string fullname)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Students where Fullname=@fullname ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@fullname", fullname);

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
        public List<Student_Users> GetStudents()
        {
            students = new List<Student_Users>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Students";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Student_Users users = new Student_Users();
                    users.Studentid = reader["id"].ToString();
                    users.Name = reader["Fullname"].ToString();
                    users.Sex = reader["Sex"].ToString();
                    users.Address = reader["Address"].ToString();
                    users.Phone = reader["phone"].ToString();
                    users.DateOfBirth = (DateTime)reader["Dateofbirth"];
                    users.Class_Name = reader["Class_Name"].ToString(); ;
                    students.Add(users);
                }

                reader.Close();
            }

            return students;
        }
        public List<Student_Users> FindStudents(string fullname1)
        {
            students = new List<Student_Users>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Students where Fullname=@fullname";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@fullname", fullname1);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Student_Users users = new Student_Users();
                    users.Studentid = reader["id"].ToString();
                    users.Name = reader["Fullname"].ToString();
                    users.Sex = reader["Sex"].ToString();
                    users.Address = reader["Address"].ToString();
                    users.Phone = reader["phone"].ToString();
                    users.DateOfBirth = (DateTime)reader["Dateofbirth"];
                    users.Class_Name = reader["Class_Name"].ToString(); ;
                    students.Add(users);
                }

                reader.Close();
            }

            return students;
        }
        public void AddStudent(Student_Users users)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "INSERT INTO Students (id,Fullname,Sex,dateofbirth,phone,Class_Name,Address) " +
                    "VALUES (@id, @Fullname, @Sex, @dateofbirth,@Phone, @Class_Name, @Address)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", users.Studentid);
                command.Parameters.AddWithValue("@Fullname", users.Name);
                command.Parameters.AddWithValue("@Sex", users.Sex);
                command.Parameters.AddWithValue("@Phone", users.Phone);
                command.Parameters.AddWithValue("@dateOfBirth", users.DateOfBirth);
                command.Parameters.AddWithValue("@Class_Name", users.Class_Name);
                command.Parameters.AddWithValue("@Address", users.Address);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void UpdateStudent(Student_Users users)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "UPDATE Students SET Fullname = @FullName, phone = @Phone, " +
                "dateofbirth = @DateOfBirth, Sex = @Sex , Class_Name=@Class_Name, Address=@Address " +
                "WHERE id = @UserId";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", users.Studentid);
                command.Parameters.AddWithValue("@Fullname", users.Name);
                command.Parameters.AddWithValue("@Sex", users.Sex);
                command.Parameters.AddWithValue("@Phone", users.Phone);
                command.Parameters.AddWithValue("@dateOfBirth", users.DateOfBirth);
                command.Parameters.AddWithValue("@Class_Name", users.Class_Name);
                command.Parameters.AddWithValue("@Address", users.Address);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void DeleteStudent(string id)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "DELETE FROM Students WHERE id = @UserId";

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
                string query = "SELECT TOP 1 id FROM Students ORDER BY id DESC";
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
                return "HV" + ms;
            }

        }

    }
}
