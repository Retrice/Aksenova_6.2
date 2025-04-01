using System;
using System.Data.SqlClient;

namespace WpfApp1
{
    public static class DatabaseHelper
    {
        private static string connectionString = "Data Source=localhost;Initial Catalog=ege_site_db;Integrated Security=True";

        public static bool UserExists(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT COUNT(*) FROM users WHERE Email = @Email", conn);
                cmd.Parameters.AddWithValue("@Email", email);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public static bool RegisterUser(string nickname, string email, string password, string name = null, string surname = null, string description = null, string institution = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand("INSERT INTO users (Nickname, Email, Password, Name, Surname, Description, EducationalInstitution) VALUES (@nickname, @email, @password, @name, @surname, @description, @institution)", conn);
                    cmd.Parameters.AddWithValue("@nickname", nickname);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@name", (object)surname ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@surname", (object)surname ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@description", (object)description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@institution", (object)institution ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }

        public static bool CheckUser(string email, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT COUNT(*) FROM users WHERE Email = @Email AND Password = @Password", conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}