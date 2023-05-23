﻿using Logic.DTOs;
using Logic.Interfaces;
using Logic.Models;
using System.Data.SqlClient;

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
                string insertCustomerQuery = "INSERT INTO [Customers] (First_Name, Last_Name, Email, Phone) VALUES (@firstName, @lastName, @email, @phone);" +
                                             "SELECT SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(insertCustomerQuery, conn);

                cmd.Parameters.AddWithValue("@firstName", customerDTO.firstName);
                cmd.Parameters.AddWithValue("@lastName", customerDTO.lastName);
                cmd.Parameters.AddWithValue("@email", customerDTO.email);
                cmd.Parameters.AddWithValue("@phone", customerDTO.phone);

                conn.Open();
                int customerId = Convert.ToInt32(cmd.ExecuteScalar());
                //conn.Close();

                string insertUserQuery = "INSERT INTO [Users] (Customer_Id, Salt, Password) VALUES (@customerId, @salt, @password)";
                SqlCommand cmd2 = new SqlCommand(insertUserQuery, conn);

                cmd2.Parameters.AddWithValue("@customerId", customerId);
                cmd2.Parameters.AddWithValue("@salt", customerDTO.salt);
                cmd2.Parameters.AddWithValue("@password", customerDTO.password);
                int rowsAffected = cmd2.ExecuteNonQuery();
                conn.Close();
                return rowsAffected == 1;
            }
        }

        
        //        using (SqlTransaction transaction = conn.BeginTransaction())
        //        {
        //            try
        //            {              
        //
        //                
        //
        //                transaction.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine(ex.Message);
        //                transaction.Rollback();
        //            }
        //        }

        //}
        //public bool Add(CustomerDTO customerDTO)
        //{
        //    using (SqlConnection conn = DBConnection.CreateConnection())
        //    {
        //        string sql = "INSERT INTO [Customers](First_Name, Last_Name, Email, Phone) VALUES (@firstName, @lastName, @email, @phone)";
        //        SqlCommand cmd = new SqlCommand(sql, conn);

        //        cmd.Parameters.AddWithValue("firstName", customerDTO.firstName);
        //        cmd.Parameters.AddWithValue("lastName", customerDTO.lastName);
        //        cmd.Parameters.AddWithValue("email", customerDTO.email);
        //        cmd.Parameters.AddWithValue("phone", customerDTO.phone);
        //        conn.Open();
        //        v
        //    }
        //}

        /// <summary>
        /// This method edits new user data from the db
        /// </summary>
        /// <param name="customerDTO">object containing new user data</param>
        /// <returns>true or false depending on the outcome</returns>
        public bool Edit(CustomerDTO customerDTO)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "UPDATE [Users] SET First_Name = @firstName, LastName = @lastName, Email = @email, Password = @password, Phone = @phone WHERE (Id = @id)";
                SqlCommand cmd = new SqlCommand(sql, conn);

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

            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "SELECT COUNT(*) FROM [Customers] WHERE Email = @email";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("email", email);
                conn.Open();

                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
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
        /// This looks for a specific email in the database and returns the user data that matches the email given.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public CustomerDTO GetCustomerByEmail(string email)
        {
            CustomerDTO dto = new CustomerDTO();

            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "SELECT * FROM [Customers] WHERE Email = @email";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("email", email);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dto.Id = reader.GetInt32(0);
                        dto.firstName = reader.GetString(1);
                        dto.lastName = reader.GetString(2);
                        dto.email = reader.GetString(3);
                        dto.phone = reader.GetString(4);
                    }
                }
                conn.Close();
            }
            return dto;
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

        //    public int GetUserId(string email)
        //    {
        //        int userId = 0;

        //        using (SqlConnection conn = DBConnection.CreateConnection())
        //        {
        //            string sql = "SELECT Id FROM [Customers] WHERE Email = @email";
        //            SqlCommand cmd = new SqlCommand(sql, conn);
        //            cmd.Parameters.AddWithValue("email", email);
        //            conn.Open();

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    userId = reader.GetInt32(0);
        //                }
        //            }
        //            conn.Close();
        //        }
        //        return userId;
        //    }
        //}
    }
}
