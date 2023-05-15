using Logic.DTOs;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IUserManager
    {
        public void AddUser(CustomerDTO customerDTO);
        public bool Login(CustomerDTO customer);
        public Customer GetCustomerByEmail(string email);
    }
}
