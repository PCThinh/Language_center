using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace English_center
{
    internal class CourseModel
    {
        List<Course_Users> Courses;
        public string GetConnectionString()
        {
            Courses = new List<Course_Users>();
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
                string query = "SELECT * FROM Courses where CourseName=@coursename" ;
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
        public List<Course_Users> GetCourses()
        {
            Courses = new List<Course_Users>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Courses";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Course_Users users = new Course_Users();
                    users.Courseid = reader["id"].ToString();
                    users.CourseName = reader["CourseName"].ToString();
                    users.Duration = reader["Duration"].ToString();
                    users.startday = (DateTime)reader["StartDay"];
                    users.endday = (DateTime)reader["EndDay"];
                    users.description = reader["Description"].ToString();
                    users.language = reader["Language"].ToString();
                    users.NameTeacher = reader["NameTeacher"].ToString();
                    users.price = reader["Price"].ToString(); ;
                    users.level = reader["level"].ToString();
                    users.teachinghours = reader["Teachinghours"].ToString();
                    users.status = reader["status"].ToString();
                    Courses.Add(users);
                }

                reader.Close();
            }

            return Courses;
        }
        public List<Course_Users> FindLevel(string level)
        {
            Courses = new List<Course_Users>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Courses where Level=@level";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@level", level);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Course_Users users = new Course_Users();
                    users.Courseid = reader["id"].ToString();
                    users.CourseName = reader["CourseName"].ToString();
                    users.Duration = reader["Duration"].ToString();
                    users.startday = (DateTime)reader["StartDay"];
                    users.endday = (DateTime)reader["EndDay"];
                    users.description = reader["Description"].ToString();
                    users.language = reader["Language"].ToString();
                    users.NameTeacher = reader["NameTeacher"].ToString();
                    users.price = reader["Price"].ToString(); ;
                    users.level = reader["Level"].ToString();
                    users.teachinghours = reader["Teachinghours"].ToString();
                    users.status = reader["Status"].ToString();
                    Courses.Add(users);
                }

                reader.Close();
            }

            return Courses;
        }
        public List<Course_Users> FindLanguage(string language1)
        {
            Courses = new List<Course_Users>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Courses where Language = @Language";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Language", language1);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Course_Users users = new Course_Users();
                    users.Courseid = reader["id"].ToString();
                    users.CourseName = reader["CourseName"].ToString();
                    users.Duration = reader["Duration"].ToString();
                    users.startday = (DateTime)reader["StartDay"];
                    users.endday = (DateTime)reader["EndDay"];
                    users.description = reader["Description"].ToString();
                    users.language = reader["Language"].ToString();
                    users.NameTeacher = reader["NameTeacher"].ToString();
                    users.price = reader["Price"].ToString(); ;
                    users.level = reader["Level"].ToString();
                    users.teachinghours = reader["Teachinghours"].ToString();
                    users.status = reader["Status"].ToString();
                    Courses.Add(users);
                }

                reader.Close();
            }

            return Courses;
        }
        public List<Course_Users> FindStatus(string status)
        {
            Courses = new List<Course_Users>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Courses where Status=@status";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@status", status);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Course_Users users = new Course_Users();
                    users.Courseid = reader["id"].ToString();
                    users.CourseName = reader["CourseName"].ToString();
                    users.Duration = reader["Duration"].ToString();
                    users.startday = (DateTime)reader["StartDay"];
                    users.endday = (DateTime)reader["EndDay"];
                    users.description = reader["Description"].ToString();
                    users.language = reader["Language"].ToString();
                    users.NameTeacher = reader["NameTeacher"].ToString();
                    users.price = reader["Price"].ToString(); ;
                    users.level = reader["level"].ToString();
                    users.teachinghours = reader["Teachinghours"].ToString();
                    users.status = reader["status"].ToString();
                    Courses.Add(users);
                }

                reader.Close();
            }

            return Courses;
        }
        public List<Course_Users> FindCourses(string coursename)
        {
            Courses = new List<Course_Users>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Courses where CourseName=@coursename";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@coursename", coursename);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Course_Users users = new Course_Users();
                    users.Courseid = reader["id"].ToString();
                    users.CourseName = reader["CourseName"].ToString();
                    users.Duration = reader["Duration"].ToString();
                    users.startday = (DateTime)reader["StartDay"];
                    users.endday = (DateTime)reader["EndDay"];
                    users.description = reader["Description"].ToString();
                    users.language = reader["Language"].ToString();
                    users.NameTeacher = reader["NameTeacher"].ToString();
                    users.price = reader["Price"].ToString(); ;
                    users.level = reader["level"].ToString();
                    users.teachinghours = reader["Teachinghours"].ToString();
                    users.status = reader["status"].ToString();
                    Courses.Add(users);
                }

                reader.Close();
            }

            return Courses;
        }
        public void AddCourse(Course_Users users)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "INSERT INTO Courses (id,CourseName,Duration,StartDay,EndDay,Description,Language,NameTeacher,Price,Level,Teachinghours,status) " +
                    "VALUES (@id, @CourseName, @Duration, @StartDay,@EndDay, @Description, @Language, @NameTeacher,@Price,@Level,@Teachinghours,@status)";  
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", users.Courseid);
                command.Parameters.AddWithValue("@Coursename", users.CourseName);
                command.Parameters.AddWithValue("@Duration", users.Duration);
                command.Parameters.AddWithValue("@StartDay", users.startday);
                command.Parameters.AddWithValue("@EndDay", users.endday);
                command.Parameters.AddWithValue("@Description", users.description);
                command.Parameters.AddWithValue("@Language", users.language);
                command.Parameters.AddWithValue("@NameTeacher", users.NameTeacher);
                command.Parameters.AddWithValue("@Price", users.price);
                command.Parameters.AddWithValue("@Level", users.level);
                command.Parameters.AddWithValue("@Teachinghours", users.teachinghours);
                command.Parameters.AddWithValue("@status", users.status);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void UpdateCourse(Course_Users users)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "UPDATE Courses SET id = @id, CourseName = @CourseName, " +
                "Duration = @Duration, StartDay = @StartDay ,EndDay=@EndDay, Description=@Description, Language=@Language,NameTeacher=@NameTeacher,Price=@Price,Level=@Level,Teachinghours=@Teachinghours,Status=@status " +
                "WHERE id = @id";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", users.Courseid);
                command.Parameters.AddWithValue("@Coursename", users.CourseName);
                command.Parameters.AddWithValue("@Duration", users.Duration);
                command.Parameters.AddWithValue("@StartDay", users.startday);
                command.Parameters.AddWithValue("@EndDay", users.endday);
                command.Parameters.AddWithValue("@Description", users.description);
                command.Parameters.AddWithValue("@Language", users.language);
                command.Parameters.AddWithValue("@NameTeacher", users.NameTeacher);
                command.Parameters.AddWithValue("@Price", users.price);
                command.Parameters.AddWithValue("@Level", users.level);
                command.Parameters.AddWithValue("@Teachinghours", users.teachinghours);
                command.Parameters.AddWithValue("@status", users.status);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void DeleteCourse(string id)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "DELETE FROM Courses WHERE id = @UserId";

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
                    string query = "SELECT TOP 1 id FROM Courses ORDER BY id DESC ";
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
                return "Course" + ms;
            }

        }

    }
}
