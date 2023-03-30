using Logic.DTOs;
using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBs
{
    public class UserDataHandler : IUserDataHandler
    {
        /// <summary>
        /// This method adds user data to the database
        /// </summary>
        /// <param name="customerDTO">object containing user data</param>
        /// <returns>true or false depending on the outcome</returns>
        public bool Add(CustomerDTO customerDTO)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "INSERT INTO [Users](First_Name, Last_Name, Email, Phone, Salt, Password) VALUES (@firstName, @lastName, @email, @phone, @salt, @password)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("firstName", customerDTO.firstName);
                cmd.Parameters.AddWithValue("lastName", customerDTO.lastName);
                cmd.Parameters.AddWithValue("email", customerDTO.email);
                cmd.Parameters.AddWithValue("phone", customerDTO.phone);
                cmd.Parameters.AddWithValue("salt", customerDTO.salt);
                cmd.Parameters.AddWithValue("password", customerDTO.password);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsAffected == 1;
            }
        }

        /// <summary>
        /// This method edits new user data from the db
        /// </summary>
        /// <param name="customerDTO">object containing new user data</param>
        /// <returns>true or false depending on the outcome</returns>
        public bool Edit(CustomerDTO customerDTO)
        {
            using(SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "UPDATE [Users] SET First_Name = @firstName, LastName = @lastName, Email = @email, Password = @password, Phone = @phone WHERE (Id = @id)";
                SqlCommand cmd = new SqlCommand(sql,conn);

                cmd.Parameters.AddWithValue("id", customerDTO.Id);
                cmd.Parameters.AddWithValue("firstName", customerDTO.firstName);
                cmd.Parameters.AddWithValue("lastName", customerDTO.lastName);
                cmd.Parameters.AddWithValue("email", customerDTO.email);
                cmd.Parameters.AddWithValue("password", customerDTO.password);
                cmd.Parameters.AddWithValue("phone", customerDTO.phone);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsAffected == 1;
            }
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method checks if a given email is already used or not
        /// </summary>
        /// <param name="email">The email that has to be checked</param>
        /// <returns>true or false depending if the email exists in the db or not</returns>'
        public bool IsEmailUsed(string email)
        {
            bool IsEmailUsed = false; 

            using(SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "SELECT COUNT(*) FROM [Users] WHERE Email = @email";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("email", email);
                conn.Open();

                int count = (int)cmd.ExecuteScalar();
                if(count > 0)
                {
                    IsEmailUsed = true;
                }
                conn.Close();
            }
            return IsEmailUsed;
        }

        /// <summary>
        /// This takes an email address as a parameter and retrieves the associated password from a SQL database.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public (string password, string salt) GetPasswordAndSaltByEmail(string email)
        {
            string password = null;
            string salt = null;

            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "SELECT Password, Salt FROM [Users] WHERE Email = @email";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("email", email);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        password = reader.GetString(0);
                        salt = reader.GetString(1);
                    }
                }
                conn.Close();
            }
            return (password, salt);
        }
        
        /// <summary>
        /// This method removes user data from database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Remove()
        {
            throw new NotImplementedException();
        }
    }
}
