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
    }
}
