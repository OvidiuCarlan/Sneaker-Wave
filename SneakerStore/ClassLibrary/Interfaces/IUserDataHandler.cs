using Logic.DTOs;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IUserDataHandler
    {
        public bool Add(CustomerDTO customerDTO);
        public bool Remove();
        public bool Edit(CustomerDTO customerDTO);
        public List<User> GetAll();
        public bool IsEmailUsed(string email);
        public (string password, string salt) GetPasswordAndSaltByEmail(string email);
        public CustomerDTO GetCustomerByEmail(string email);
        //public int GetUserId(string email);
    }
}
