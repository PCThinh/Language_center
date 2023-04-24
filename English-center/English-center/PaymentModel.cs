using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_center
{
    internal class PaymentModel
    {
        List<Payment_Users> Payments;
        public string GetConnectionString()
        {
            Payments = new List<Payment_Users>();
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
        public bool Find(string name)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Payments where Name=@name";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", name);
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
        public List<Payment_Users> GetPayments()
        {
            Payments = new List<Payment_Users>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Payments";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Payment_Users users = new Payment_Users();
                    users.Paymentid = reader["id"].ToString();
                    users.Paymentdate = (DateTime)reader["PaymentDate"];
                    users.Paymentmethod = reader["Paymentmethod"].ToString();
                    users.Coursename = reader["CourseName"].ToString(); ;
                    users.Name = reader["Name"].ToString();
                    users.Price = reader["Price"].ToString();
                    users.Paymentinfo = reader["Paymentinfo"].ToString();
                    users.Duedate = (DateTime)reader["Duedate"];
                    users.status = reader["status"].ToString(); ;
                    users.Debt = reader["Debt"].ToString();
                    users.Paid = reader["Paid"].ToString();
                    Payments.Add(users);
                }

                reader.Close();
            }

            return Payments;
        }
        public List<Payment_Users> FindPayments(string name)
        {
            Payments = new List<Payment_Users>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Payments where Name=@name";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", name);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Payment_Users users = new Payment_Users();
                    users.Paymentid = reader["id"].ToString();
                    users.Paymentdate = (DateTime)reader["PaymentDate"];
                    users.Paymentmethod = reader["Paymentmethod"].ToString();
                    users.Coursename = reader["CourseName"].ToString(); ;
                    users.Name = reader["Name"].ToString();
                    users.Price = reader["Price"].ToString();
                    users.Paymentinfo = reader["Paymentinfo"].ToString();
                    users.Duedate = (DateTime)reader["Duedate"];
                    users.status = reader["status"].ToString(); ;
                    users.Debt = reader["Debt"].ToString();
                    users.Paid = reader["Paid"].ToString();
                    Payments.Add(users);
                }

                reader.Close();
            }

            return Payments;
        }
        public void AddPayment(Payment_Users users)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "INSERT INTO Payments (id,PaymentDate,Paymentmethod,CourseName,Name,Price,Paymentinfo,DueDate,Status,Debt,Paid) " +
                    "VALUES (@id,@PaymentDate,@Paymentmethod,@CourseName,@Name,@Price,@Paymentinfo,@DueDate,@Status,@Debt,@Paid)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", users.Paymentid);
                command.Parameters.AddWithValue("@PaymentDate", users.Paymentdate);
                command.Parameters.AddWithValue("@Paymentmethod", users.Paymentmethod);
                command.Parameters.AddWithValue("@CourseName", users.Coursename);
                command.Parameters.AddWithValue("@Name", users.Name);
                command.Parameters.AddWithValue("@Price", users.Price);
                command.Parameters.AddWithValue("@Paymentinfo", users.Paymentinfo);
                command.Parameters.AddWithValue("@DueDate", users.Duedate);
                command.Parameters.AddWithValue("@Status", users.status);
                command.Parameters.AddWithValue("@Debt", users.Debt);
                command.Parameters.AddWithValue("@Paid", users.Paid);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void UpdatePayment(Payment_Users users)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "UPDATE Payments SET id = @id, PaymentDate = @PaymentDate, " + "Paymentmethod = @Paymentmethod, CourseName = @CourseName ,Name=@Name, Price=@Price, Paymentinfo=@Paymentinfo,DueDate=@DueDate,Status=@Status,Debt=@Debt,Paid=@Paid " +
                "WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", users.Paymentid);
                command.Parameters.AddWithValue("@PaymentDate", users.Paymentdate); 
                command.Parameters.AddWithValue("@Paymentmethod", users.Paymentmethod);
                command.Parameters.AddWithValue("@CourseName", users.Coursename);
                command.Parameters.AddWithValue("@Name", users.Name);
                command.Parameters.AddWithValue("@Price", users.Price);
                command.Parameters.AddWithValue("@Paymentinfo", users.Paymentinfo);
                command.Parameters.AddWithValue("@DueDate", users.Duedate);
                command.Parameters.AddWithValue("@Status", users.status);
                command.Parameters.AddWithValue("@Debt", users.Debt);
                command.Parameters.AddWithValue("@Paid", users.Paid);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void DeletePayment(string id)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "DELETE FROM Payments WHERE id = @PaymentId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PaymentId", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public string AutoID(string datetime)
        {
            string id = "";
            string ms = "";
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT TOP 1 id FROM Payments WHERE id LIKE '%" + datetime + "%' ORDER BY id DESC";
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
                return datetime + ms;
            }

        }

    }
}
