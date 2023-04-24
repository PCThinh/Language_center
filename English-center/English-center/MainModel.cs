using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace English_center
{
    internal class MainModel
    {
        public string GetConnectionString()
        {
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
        public string checkusername(string name)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT position from Users where username=@name";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", name);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string position = reader["position"].ToString();
                    return position;
                }
                return "";
            }
        }
    }
}