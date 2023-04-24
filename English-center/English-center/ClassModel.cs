using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_center
{
    internal class ClassModel
    {
        List<Class_Users> Classes;
        public string GetConnectionString()
        {
            Classes = new List<Class_Users>();
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
        public bool Find(string coursename)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Classes where CourseName=@coursename" ;
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@coursename",coursename);
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
        public List<Class_Users> GetCourses()
        {
            Classes = new List<Class_Users>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Classes";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Class_Users users = new Class_Users();
                    users.id = reader["id"].ToString();
                    users.NameCourse = reader["CourseName"].ToString();
                    users.status = reader["status"].ToString();
                    Classes.Add(users);
                }

                reader.Close();
            }

            return Classes;
        }
        public List<Class_Users> FindLevel(string level)
        {
            Classes = new List<Class_Users>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Classes where Level=@level";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@level", level);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Class_Users users = new Class_Users();
                    users.status = reader["Status"].ToString();
                    Classes.Add(users);
                }

                reader.Close();
            }

            return Classes;
        }
        public List<Class_Users> FindLanguage(string language1)
        {
            Classes = new List<Class_Users>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Classes where Language = @Language";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Language", language1);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Class_Users users = new Class_Users();

                    Classes.Add(users);
                }

                reader.Close();
            }

            return Classes;
        }
        public List<Class_Users> FindStatus(string status)
        {
            Classes = new List<Class_Users>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Classes where Status=@status";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@status", status);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Class_Users users = new Class_Users();
                    users.status = reader["status"].ToString();
                    Classes.Add(users);
                }

                reader.Close();
            }

            return Classes;
        }
        public List<Class_Users> FindCourses(string coursename)
        {
            Classes = new List<Class_Users>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Classes where CourseName=@coursename";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@coursename", coursename);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Class_Users users = new Class_Users();
                    Classes.Add(users);
                }

                reader.Close();
            }

            return Classes;
        }
        public void AddCourse(Class_Users users)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "INSERT INTO Classes (id,CourseName,Duration,StartDay,EndDay,Description,Language,NameTeacher,Price,Level,Teachinghours,status) " +
                    "VALUES (@id, @CourseName, @Duration, @StartDay,@EndDay, @Description, @Language, @NameTeacher,@Price,@Level,@Teachinghours,@status)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@status", users.status);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void UpdateCourse(Class_Users users)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "UPDATE Classes SET id = @id, CourseName = @CourseName, " +
                "Duration = @Duration, StartDay = @StartDay ,EndDay=@EndDay, Description=@Description, Language=@Language,NameTeacher=@NameTeacher,Price=@Price,Level=@Level,Teachinghours=@Teachinghours,Status=@status " +
                "WHERE id = @id";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@status", users.status);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void DeleteCourse(string id)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "DELETE FROM Classes WHERE id = @UserId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public string AutoID()
        {
            string id = "";
            string ms = "";
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                    string query = "SELECT TOP 1 id FROM Classes ORDER BY id DESC ";
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
                return "Class" + ms;
            }

        }

    }
}
