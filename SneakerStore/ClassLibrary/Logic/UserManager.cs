using Logic.DTOs;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class UserManager
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
                _userDataHandler.Add(customerDTO);
            }
            else
            {
                throw new Exception("Email is already used");
            }
        }

        public void RemoveUser()
        {

        }
    }
}
