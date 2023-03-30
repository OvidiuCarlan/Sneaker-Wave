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
                string sql = "INSERT INTO [Users](First_Name, Last_Name, Email, Password, Phone) VALUES (@firstName, @lastName, @email, @password, @phone)";
                SqlCommand cmd = new SqlCommand(sql, conn);

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

        public bool Remove()
        {
            throw new NotImplementedException();
        }
    }
}
