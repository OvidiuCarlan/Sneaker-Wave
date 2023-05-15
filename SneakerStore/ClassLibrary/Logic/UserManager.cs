using Logic.DTOs;
using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class UserManager : IUserManager
    {
        private readonly IUserDataHandler _userDataHandler;
        public UserManager (IUserDataHandler userDb)
        {
            _userDataHandler = userDb;
        }

        /// <summary>
        /// This method checks if email is used and if not it sends user data to the DAL layer
        /// </summary>
        /// <param name="customerDTO">Object containing user data</param>
        public void AddUser(CustomerDTO customerDTO)
        {
            bool isEmailUsed = _userDataHandler.IsEmailUsed(customerDTO.email);
            if (!isEmailUsed)
            {
                (string passwordSalt, string hashedPassword) = Security.CreateSaltAndHash(customerDTO.password);
                customerDTO.salt = passwordSalt;
                customerDTO.password = hashedPassword;

                _userDataHandler.Add(customerDTO);
            }
            else
            {
                throw new Exception("Email is already used");
            }
        }
        public bool Login(CustomerDTO customer)
        {
            (string dBpassword, string salt) = _userDataHandler.GetPasswordAndSaltByEmail(customer.email);

            if (dBpassword == null || salt == null)
            {
                throw new Exception("Email is not correct");
            }

            string hashedInputedPass = Security.CreateHash(salt, customer.password);

            if (!hashedInputedPass.Equals(dBpassword))
            {
                throw new Exception("Password is not correct");
            }
            return true;
        }
        public Customer GetCustomerByEmail(string email)
        {
            Customer customer = new Customer(_userDataHandler.GetCustomerByEmail(email));
            return customer;
        }
    }
}
